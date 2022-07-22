class Anexo {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Anexo";
        this.mensajeGuardadoExito = "Se ha guardado el Anexo.";
        this.mensajeEliminadoExito = "Se ha eliminado el Anexo.";
        this.contenedorErrorDefault = "#popup-detail .container-detail-form label.error-label";
    }
    GetDataCrls() {
        let idTramiteCtrl = document.querySelector(".form-edit-container #IdTramite");
        let idAnexoTramiteCtrl = document.querySelector("#popup-detail #IdAnexoTramite");
        let linkCtrl = document.querySelector("#popup-detail #enlaceDetailEdit");
        let data = {};

        if (idTramiteCtrl != undefined)
            data["idtramite"] = idTramiteCtrl.value;
        if (idAnexoTramiteCtrl != undefined)
            data["idanexotramite"] = idAnexoTramiteCtrl.value;
        if (linkCtrl != undefined)
            data["link"] = linkCtrl.value;

        return data;
    }
    ExecuteValidation(data) {
        let objRespuesta = { isvalid: true, mensaje: "" };

        if (data.link == null || data.link == undefined || data.link == "") {
            objRespuesta.mensaje = "El enlace es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }

        return objRespuesta;
    }
    FnCallbackDetailGuardarSuccess(response) {
        if (response == null || response == undefined) {
            console.error("La respuesta desde el servidor es vacío.");
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, "Se ha producido un error en el aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, response.mensaje);
            return;
        }
        eMASReferencialJs.cerrarPopupDetail();
        objSMC50002.CallbackPosGuardarDetalleExito(this.name, this.mensajeGuardadoExito);
    }
    FnCallbackDetailEliminarSuccess(response) {
        if (response == null || response == undefined) {
            console.error("La respuesta desde el servidor es vacío.");
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        }
        objSMC50002.CallbackPosEliminarDetalleExito(this.name, this.mensajeEliminadoExito);
    }
    FnCallbackDetailGuardar() {
        eMASReferencialJs.SetearLabelError(false, this.contenedorErrorDefault);
        // getdata
        let data = this.GetDataCrls();
        // valida
        let resVal = this.ExecuteValidation(data);

        if (!resVal.isvalid) {
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, resVal.mensaje);
            return;
        }
        let dataBody = {
            model: JSON.stringify(data),
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/EditDetailSave"
            , dataBody, this.FnCallbackDetailGuardarSuccess.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    FnCallbackDetailCancelar() {
        eMASReferencialJs.cerrarPopupDetail();
    }
    FnCallbackBtnNuevoSuccess(data) {
        let btnGuardarDetail = document.querySelector("#popup-detail button.guardar-edit-detail");
        let btnCancelarDetail = document.querySelector("#popup-detail button.cancelar-edit-detail");
        if (btnCancelarDetail != undefined) {
            btnCancelarDetail.removeEventListener("click", this.FnCallbackDetailCancelar.bind(this));
            btnCancelarDetail.addEventListener("click", this.FnCallbackDetailCancelar.bind(this));
        }
        
        if (btnGuardarDetail != undefined) {
            btnGuardarDetail.removeEventListener("click", this.FnCallbackDetailGuardar.bind(this));
            btnGuardarDetail.addEventListener("click", this.FnCallbackDetailGuardar.bind(this));
        }
        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general textarea.text-control");
    }
    FnCallbackBtnNuevo(evt) {
        this.FnEditarElemento("Agregar Anexo");
    }
    FnEliminarElemento() {
        let dataBody = {
            id: this.id.toString(),
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/EditDetailDelete"
            , dataBody, this.FnCallbackDetailEliminarSuccess.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    FnEditarElemento(titulo) {
        let dataBody = {
            id: this.id.toString(),
            entidad: this.name
        };
        let strTitulo = "";
        if (titulo == undefined)
            strTitulo = "Actualizar Anexo";
        else
            strTitulo = titulo;

        eMASReferencialJs.mostrarPopupDetail(strTitulo, "Comodatos/SMC50002/EditDetailView", dataBody, this.FnCallbackBtnNuevoSuccess.bind(this));
    }
    FnListarAll() {
        let dataBody = {
            idtramite: this.idTramite,
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail", dataBody, this.fillDataResponse.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-anexo-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", this.FnCallbackBtnNuevo.bind(this), false);
        }
        let btnRefresh = document.querySelector(".container-anexo-detail button.refresh-detail");
        if (btnRefresh != undefined) {
            btnRefresh.addEventListener("click", this.FnListarAll.bind(this), false);
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
                    columns: [{},{}, {}]
            });
            return;
        }
        let data = [];
        
        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                enlace: response.dataresult[i].link,
                id: response.dataresult[i].idanexotramite
            });
        }

        DataDetail.bootstrapTable({
            data: data,
            columns: [{
                field: 'acciones',
                title: 'Acciones',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: function (value, row, index) {
                    let strFnButtons = '<button type="button" onclick="objSMC50002.BtnEditRowItemDetail(' + row.id + ',\'Anexo\' );" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button>';
                    //strFnButtons += '<button type="button" onclick="objSMC50002.BtnDeleteRowItemDetail(' + row.id + ',\'Anexo\' );" title="Eliminar" class=\'btn btn-outline-primary \'><i class="fa fa-trash"></i></button>';
                    return strFnButtons;
                }
            },
            {}, {}]
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
        this.mensajeGuardadoExito = "Se ha guardado el registro.";
        this.mensajeEliminadoExito = "Se ha eliminado el registro.";
        this.contenedorErrorDefault = "#popup-detail .container-detail-form label.error-label";
    }
    GetDataCrls() {
        
        let idTramiteCtrl = document.querySelector(".form-edit-container #IdTramite");
        let idObservacionTramiteCtrl = document.querySelector("#popup-detail #IdObservacionTramite");
        let observacionCtrl = document.querySelector("#popup-detail #observacionDetail");
        let fechaObservacionCtrl = document.querySelector("#popup-detail #fechaObervacionDetail");
        let data = {};

        if (idTramiteCtrl != undefined)
            data["idtramite"] = idTramiteCtrl.value;
        if (idObservacionTramiteCtrl != undefined)
            data["idtramitedesc"] = idObservacionTramiteCtrl.value;
        if (observacionCtrl != undefined)
            data["observacion"] = observacionCtrl.value;

        let _fechaObservacion = "";
        if (fechaObservacionCtrl != undefined) {
            _fechaObservacion = eMASReferencialJs.FormatearFecha(fechaObservacionCtrl.value);
            data["fecha"] = _fechaObservacion;
        }

        return data;
    }
    ExecuteValidation(data) {
        let objRespuesta = { isvalid: true, mensaje: "" };

        if (data.observacion == null || data.observacion == undefined || data.observacion == "") {
            objRespuesta.mensaje = "La Observaci&oacute; es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }

        return objRespuesta;
    }
    FnCallbackDetailGuardarSuccess(response) {
        if (response == null || response == undefined) {
            console.error("La respuesta desde el servidor es vacío.");
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, "Se ha producido un error en el aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, response.mensaje);
            return;
        }
        eMASReferencialJs.cerrarPopupDetail();
        objSMC50002.CallbackPosGuardarDetalleExito(this.name, this.mensajeGuardadoExito);
    }
    FnCallbackDetailEliminarSuccess(response) {
        if (response == null || response == undefined) {
            console.error("La respuesta desde el servidor es vacío.");
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        }
        objSMC50002.CallbackPosEliminarDetalleExito(this.name, this.mensajeEliminadoExito);
    }
    FnCallbackDetailGuardar() {
        eMASReferencialJs.SetearLabelError(false, this.contenedorErrorDefault);
        // getdata
        let data = this.GetDataCrls();
        // valida
        let resVal = this.ExecuteValidation(data);

        if (!resVal.isvalid) {
            eMASReferencialJs.SetearLabelError(true, this.contenedorErrorDefault, resVal.mensaje);
            return;
        }
        let dataBody = {
            model: JSON.stringify(data),
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/EditDetailSave"
            , dataBody, this.FnCallbackDetailGuardarSuccess.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    FnCallbackDetailCancelar() {
        eMASReferencialJs.cerrarPopupDetail();
    }
    FnCallbackBtnNuevoSuccess(data) {
        let btnGuardarDetail = document.querySelector("#popup-detail button.guardar-edit-detail");
        let btnCancelarDetail = document.querySelector("#popup-detail button.cancelar-edit-detail");
        if (btnCancelarDetail != undefined) {
            btnCancelarDetail.removeEventListener("click", this.FnCallbackDetailCancelar.bind(this));
            btnCancelarDetail.addEventListener("click", this.FnCallbackDetailCancelar.bind(this));
        }
        if (btnGuardarDetail != undefined) {
            btnGuardarDetail.removeEventListener("click", this.FnCallbackDetailGuardar.bind(this));
            btnGuardarDetail.addEventListener("click", this.FnCallbackDetailGuardar.bind(this));
        }
        
        let fechaObservacion = document.querySelector("#fechaObervacionDetail");
        if (fechaObservacion != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaObervacionDetail");

        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general textarea.text-control");
    }
    FnCallbackBtnNuevo(evt) {
        this.FnEditarElemento("Agregar Observaci&oacute;n");
    }
    FnEliminarElemento() {
        let dataBody = {
            id: this.id.toString(),
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/EditDetailDelete"
            , dataBody, this.FnCallbackDetailEliminarSuccess.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    FnEditarElemento(titulo) {
        let dataBody = {
            id: this.id.toString(),
            entidad: this.name
        };
        let strTitulo = "";
        if (titulo == undefined)
            strTitulo = "Actualizar Observaci&oacute;n";
        else
            strTitulo = titulo;

        eMASReferencialJs.mostrarPopupDetail(strTitulo, "Comodatos/SMC50002/EditDetailView", dataBody, this.FnCallbackBtnNuevoSuccess.bind(this));
    }
    FnListarAll() {
        let dataBody = {
            idtramite: this.idTramite,
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail", dataBody, this.fillDataResponse.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-observacion-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", this.FnCallbackBtnNuevo.bind(this), false);
        }
        let btnRefresh = document.querySelector(".container-observacion-detail button.refresh-detail");
        if (btnRefresh != undefined) {
            btnRefresh.addEventListener("click", this.FnListarAll.bind(this), false);
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
                    columns: [{}, {}, {}, {}]
                });
            return;
        }
        let data = [];

        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                fecha: response.dataresult[i].strfecha,
                observacion: response.dataresult[i].observacion,
                id: response.dataresult[i].idtramitedesc
            });
        }

        DataDetail.bootstrapTable({
            data: data,
            columns: [{
                field: 'acciones',
                title: 'Acciones',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: function (value, row, index) {
                    let strFnButtons = '<button type="button" onclick="objSMC50002.BtnEditRowItemDetail(' + row.id + ',\'Observacion\' );" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button>';
                    //strFnButtons += '<button type="button" onclick="objSMC50002.BtnDeleteRowItemDetail(' + row.id + ',\'Observacion\' );" title="Eliminar" class=\'btn btn-outline-primary \'><i class="fa fa-trash"></i></button>';
                    return strFnButtons;
                }
            },
                {}, {}, {}]
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
            Observacion,
            Oficio,
            Topografia
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
        objEntityDetail.FnListarAll();
        /*
        let dataBody = {
            idtramite: this.idParentEntiy,
            entidad: objEntityDetail.nameEntity()
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail", dataBody, objEntityDetail.fillDataResponse, eMASReferencialJs.FnGeneralVacia, "");
        */
    }
    GetById() {
        let objEntityDetail = new this.EntityDetailFactory[this.entityName](this.idParentEntiy, this.id);
        objEntityDetail.FnEditarElemento();
    }
    DeleteById() {
        let objEntityDetail = new this.EntityDetailFactory[this.entityName](this.idParentEntiy, this.id);
        objEntityDetail.FnEliminarElemento();
    }
    Save() {
        this.ValidateSaveData();
    }
    Delete() {
    }
}