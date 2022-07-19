class Anexo {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Anexo";
    }
    ExecuteValidation() {
    }
    BindearEventosFormulario() {
    }
    FnCallbackBtnNuevoSuccess(data) {
        //Bindear Eventos de formulario
        console.log("ya regres&oacute; al cliente");
    }
    FnCallbackBtnNuevo(evt) {
        let dataBody = {
            id: this.id.toString(),
            entidad: this.name
        };
        console.table(dataBody);
        eMASReferencialJs.mostrarPopupDetail("Agregar Anexo", "Comodatos/SMC50002/EditDetailView", dataBody, this.FnCallbackBtnNuevoSuccess);
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-anexo-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", this.FnCallbackBtnNuevo.bind(this), false);
        }
    }
    fillDataResponse(response) {
        let DataDetail = $(".container-anexo-detail table");
        DataDetail.bootstrapTable('destroy');
        let resultadoIncorrecto = false;
        let sinDatos = false;
        if (response == null || response == undefined) {
            console.error("Se produjo una respuesta nula desde el servidor.");
            resultadoIncorrecto = true;
        }
        if (response.tipo != "EXITO") {
            console.error("Se produjo una respuesta nula desde el servidor.");
            console.error(response.mensaje);
            resultadoIncorrecto = true;
        }
        if (response.dataresult == null || response.dataresult == undefined) {
            console.log("No hay datos desde el servidor");
            sinDatos = true;
        }
        if (response.dataresult.length == 0) {
            console.log("No hay datos desde el servidor");
            sinDatos = true;
        }
        if (resultadoIncorrecto || sinDatos) {
            DataDetail.bootstrapTable(
                {
                    columns: [
                        {
                            field: "acciones",
                        },
                        {
                            field: "enlace",
                        }]
            });
            return;
        }
        let data = [];
        
        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                enlace: response.dataresult[i].link
            });
        }

        DataDetail.bootstrapTable({
            data: data,
            columns: [{
                field: 'actions',
                title: 'Acciones',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: function (value, row, index) {
                    return '<button type="button" onclick="objSMC50002.BtnEditRowItem(' + '' + ');" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button> ';
                }
            },
            {
                field: 'enlace',
                title: 'Enlace',
            }]
        });
    }
    nameEntity() {
        return "Anexo";
    }
}
class Observacion {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Observacion";
    }
    ExecuteValidation() {
        console.log("me ejecutaron observacion");
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-observacion-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", function (e) {
                console.log("quieren que agregue una nueva observacion");
                eMASReferencialJs.mostrarPopupDetail("Agregar Anexo", "", "", "");
            })
        }
    }
    fillDataResponse(response) {
        let DataDetail = $(".container-observacion-detail table");
        DataDetail.bootstrapTable('destroy');
        let resultadoIncorrecto = false;
        let sinDatos = false;
        if (response == null || response == undefined) {
            console.error("Se produjo una respuesta nula desde el servidor.");
            resultadoIncorrecto = true;
        }
        if (response.tipo != "EXITO") {
            console.error("Se produjo una respuesta nula desde el servidor.");
            console.error(response.mensaje);
            resultadoIncorrecto = true;
        }
        if (response.dataresult == null || response.dataresult == undefined) {
            console.log("No hay datos desde el servidor");
            sinDatos = true;
        }
        if (response.dataresult.length == 0) {
            console.log("No hay datos desde el servidor");
            sinDatos = true;
        }
        if (resultadoIncorrecto || sinDatos) {
            DataDetail.bootstrapTable(
                {
                    columns: [
                        {
                            field: "acciones",
                        },
                        {
                            field: "fecha",
                        },
                        ,
                        {
                            field: "observacion",
                        }]
                });
            return;
        }
        let data = [];

        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                fecha: response.dataresult[i].fecha,
                observacion: response.dataresult[i].observacion,
            });
        }

        DataDetail.bootstrapTable({
            data: data,
            columns: [{
                field: 'actions',
                title: 'Acciones',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: function (value, row, index) {
                    return '<button type="button" onclick="objSMC50002.BtnEditRowItem(' + '' + ');" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button> ';
                }
            },
                {}, {}]
        });
    }
    nameEntity() {
        return "Observacion";
    }
}
class GenericDetail {    
    constructor(idParentEntiy, id, entityName) {
        this.id = id;
        this.entityName = entityName;
        this.idParentEntiy = idParentEntiy;
        this.EntityDetailFactory = {
            Anexo,
            Observacion
        }
    }
    ValidateSaveData() {
        let objEntityDetail = new this.EntityDetailFactory[entityName](idParentEntiy, 0);

        objEntityDetail.ExecuteValidation();
    }
    GetCustomDataForm() {
    }
    BindEventsModalForm() {
    }
    BindEventsTable() {
        let objEntityDetail = new this.EntityDetailFactory[this.entityName](this.idParentEntiy, this.id);

        objEntityDetail.BindearEventosCabecera();
    }
    GetListAll() {
        let objEntityDetail = new this.EntityDetailFactory[this.entityName](this.idParentEntiy, 0);

        let dataBody = {
            idtramite: this.idParentEntiy,
            entidad: objEntityDetail.nameEntity()
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail", dataBody, objEntityDetail.fillDataResponse, eMASReferencialJs.FnGeneralVacia, "");
        
    }
    GetById() {
        // Consultar
        // Setear Modal
        // Mostrar Modal
        this.BindEventsModalForm();
    }
    Save() {
        // Recuperar Data de Pantalla
        this.ValidateSaveData();

        // Cerrar Modal
    }
    Delete() {
    }
}