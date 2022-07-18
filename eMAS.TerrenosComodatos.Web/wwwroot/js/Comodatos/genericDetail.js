class Anexo {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Anexo";
    }
    ExecuteValidation() {
        //console.log("me ejecutaron anexo " + this._anexo);
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
    constructor(idParentEntiy, entityName) {
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
    }
    GetListAll() {
        let objEntityDetail = new this.EntityDetailFactory[this.entityName](this.idParentEntiy, 0);

        let dataBody = {
            idtramite: this.idParentEntiy,
            entidad: objEntityDetail.nameEntity()
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail", dataBody, objEntityDetail.fillDataResponse, eMASReferencialJs.FnGeneralVacia, "");
        // LlenarTabla
        this.BindEventsTable();
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