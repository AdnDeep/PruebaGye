class Oficio {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Oficio";
        this.dsrDireccion = "DSRDIRECCION";
        this.mensajeGuardadoExito = "Se ha guardado el Oficio.";
        this.mensajeEliminadoExito = "Se ha eliminado el Oficio.";
        this.contenedorErrorDefault = "#popup-detail .container-detail-form label.error-label";
    }
    GetDataCrls() {        
        let idTramiteCtrl = document.querySelector(".form-edit-container #IdTramite");
        let idOficioTramiteCtrl = document.querySelector("#popup-detail #IdOficioTramite");
        let direccionCtrl = document.querySelector("#popup-detail #direcciondetail");
        let oficioCtrl = document.querySelector("#popup-detail #oficioDetail");
        let fechaEnvioCtrl = document.querySelector("#popup-detail #fechaEnvioDetail");
        let oficioRespuestaCtrl = document.querySelector("#popup-detail #oficioRespuestaDetail");
        let fechaRespuestaCtrl = document.querySelector("#popup-detail #fechaRespuestaDetail");

        let data = {};

        if (idTramiteCtrl != undefined)
            data["idtramite"] = idTramiteCtrl.value;
        if (idOficioTramiteCtrl != undefined)
            data["idoficiootrasdirecciones"] = idOficioTramiteCtrl.value;
        data["secuencia"] = 0;
        if (direccionCtrl != undefined)
            data["iddireccion"] = direccionCtrl.value;

        if (oficioCtrl != undefined)
            data["oficio"] = oficioCtrl.value;
        let _fechaEnvio = "";
        if (fechaEnvioCtrl != undefined)
            _fechaEnvio = eMASReferencialJs.FormatearFecha(fechaEnvioCtrl.value);            
        data["fechaenvio"] = _fechaEnvio;

        if (oficioRespuestaCtrl != undefined)
            data["oficiorespuesta"] = oficioRespuestaCtrl.value;
        let _fechaRespuesta = "";
        if (fechaRespuestaCtrl != undefined)
            _fechaRespuesta = eMASReferencialJs.FormatearFecha(fechaRespuestaCtrl.value);
        data["fecharespuesta"] = _fechaRespuesta;

        return data;
    }
    ExecuteValidation(data) {
        let objRespuesta = { isvalid: true, mensaje: "" };

        if (data.iddireccion == null || data.iddireccion == undefined || data.iddireccion == "") {
            objRespuesta.mensaje = "La Direcci&oacute;n es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (data.oficio == null || data.oficio == undefined || data.oficio == "") {
            objRespuesta.mensaje = "El enlace es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (data.fechaenvio == null || data.fechaenvio == undefined || data.fechaenvio == "") {
            objRespuesta.mensaje = "La fecha Envio es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (!(data.oficiorespuesta == null || data.oficiorespuesta == undefined || data.oficiorespuesta == "")) {
            if (data.fecharespuesta == null || data.fecharespuesta == undefined || data.fecharespuesta == "") {
                objRespuesta.mensaje = "La fecha Respuesta es un campo obligatorio.";
                objRespuesta.isvalid = false;
                return objRespuesta;
            }
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

        let fechaEnvio = document.querySelector("#fechaEnvioDetail");
        if (fechaEnvio != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaEnvioDetail");

        let fechaRespuesta = document.querySelector("#fechaRespuestaDetail");
        if (fechaRespuesta != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaRespuestaDetail");

        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general input.text-control");
        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general textarea.text-control");
        let arr = [];
        arr.push({
            key: this.dsrDireccion, ctrl: "direcciondetail", ruta: "Comodatos/SMC50002/GetDataDsrGeneric"
            , fnCallback2: eMASReferencialJs.ConsultPosLlenarComboGeneric
            , parameter1: "direcciondetail"
            , parameter2: "IdDireccionDetail"
        });
        eMASReferencialJs.CargarCombosGenerico(arr);
    }
    FnCallbackBtnNuevo(evt) {
        this.FnEditarElemento("Agregar Oficio");
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
            strTitulo = "Actualizar Oficio";
        else
            strTitulo = titulo;

        eMASReferencialJs.mostrarPopupDetail(strTitulo, "Comodatos/SMC50002/EditDetailView"
            , dataBody, this.FnCallbackBtnNuevoSuccess.bind(this));
    }
    FnListarAll() {
        let dataBody = {
            idtramite: this.idTramite,
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail"
            , dataBody, this.fillDataResponse.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-oficio-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", this.FnCallbackBtnNuevo.bind(this), false);
        }
        let btnRefresh = document.querySelector(".container-oficio-detail button.refresh-detail");
        if (btnRefresh != undefined) {
            btnRefresh.addEventListener("click", this.FnListarAll.bind(this), false);
        }
    }
    fillDataResponse(response) {
        let DataDetail = $(".container-oficio-detail table");
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
                    columns: [{}, {}, {}, {}, {}, {}]
            });
            return;
        }
        let data = [];
        
        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                direccion: response.dataresult[i].direccion,
                secuencia: response.dataresult[i].secuencia,
                oficio: response.dataresult[i].oficio,
                oficiorespuesta: response.dataresult[i].oficiorespuesta,
                id: response.dataresult[i].idoficiootrasdirecciones
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
                    let strFnButtons = '<button type="button" onclick="objSMC50002.BtnEditRowItemDetail(' + row.id + ',\'Oficio\' );" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button>';
                    //strFnButtons += '<button type="button" onclick="objSMC50002.BtnDeleteRowItemDetail(' + row.id + ',\'Oficio\' );" title="Eliminar" class=\'btn btn-outline-primary \'><i class="fa fa-trash"></i></button>';
                    return strFnButtons;
                }
            },
            {}, {}]
        });
    }
    nameEntity() {
        return "Oficio";
    }
}
class Topografia {
    constructor(_idTramite, _id) {
        this.idTramite = _idTramite;
        this.id = _id;
        this.name = "Topografia";
        this.dsrTipoTopografia = "DSRTIPOTOPOGRAFIA";
        this.mensajeGuardadoExito = "Se ha guardado el registro.";
        this.mensajeEliminadoExito = "Se ha eliminado el registro.";
        this.contenedorErrorDefault = "#popup-detail .container-detail-form label.error-label";
    }
    GetDataCrls() {
        let idTramiteCtrl = document.querySelector(".form-edit-container #IdTramite");
        let idTopografiaTramiteCtrl = document.querySelector("#popup-detail #IdTopografiaTramite");
        let tipoTopografiaCtrl = document.querySelector("#popup-detail #tipoTopografiaDetail");
        let oficioCtrl = document.querySelector("#popup-detail #oficioDetail");
        let fechaEnvioCtrl = document.querySelector("#popup-detail #fechaEnvioDetail");
        let oficioRespuestaCtrl = document.querySelector("#popup-detail #oficioRespuestaDetail");
        let fechaRespuestaCtrl = document.querySelector("#popup-detail #fechaRespuestaDetail");

        let data = {};

        if (idTramiteCtrl != undefined)
            data["idtramite"] = idTramiteCtrl.value;
        if (idTopografiaTramiteCtrl != undefined)
            data["idtopografiaterreno"] = idTopografiaTramiteCtrl.value;
        data["secuencia"] = 0;
        if (tipoTopografiaCtrl != undefined)
            data["idtipotopografiaterreno"] = tipoTopografiaCtrl.value;

        if (oficioCtrl != undefined)
            data["oficio"] = oficioCtrl.value;
        let _fechaEnvio = "";
        if (fechaEnvioCtrl != undefined)
            _fechaEnvio = eMASReferencialJs.FormatearFecha(fechaEnvioCtrl.value);
        data["fechaenvio"] = _fechaEnvio;

        if (oficioRespuestaCtrl != undefined)
            data["oficiorespuesta"] = oficioRespuestaCtrl.value;
        let _fechaRespuesta = "";
        if (fechaRespuestaCtrl != undefined)
            _fechaRespuesta = eMASReferencialJs.FormatearFecha(fechaRespuestaCtrl.value);
        data["fecharespuesta"] = _fechaRespuesta;

        return data;
    }
    ExecuteValidation(data) {
        let objRespuesta = { isvalid: true, mensaje: "" };

        if (data.idtipotopografiaterreno == null || data.idtipotopografiaterreno == undefined || data.idtipotopografiaterreno == "") {
            objRespuesta.mensaje = "El tipo de Topograf&iacute;a es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (data.oficio == null || data.oficio == undefined || data.oficio == "") {
            objRespuesta.mensaje = "El enlace es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (data.fechaenvio == null || data.fechaenvio == undefined || data.fechaenvio == "") {
            objRespuesta.mensaje = "La fecha Envio es un campo obligatorio.";
            objRespuesta.isvalid = false;
            return objRespuesta;
        }
        if (!(data.oficiorespuesta == null || data.oficiorespuesta == undefined || data.oficiorespuesta == "")) {
            if (data.fecharespuesta == null || data.fecharespuesta == undefined || data.fecharespuesta == "") {
                objRespuesta.mensaje = "La fecha Respuesta es un campo obligatorio.";
                objRespuesta.isvalid = false;
                return objRespuesta;
            }
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
            //btnCancelarDetail.replaceWith(btnCancelarDetail.cloneNode(true));
            btnCancelarDetail.removeEventListener("click", this.FnCallbackDetailCancelar.bind(this));
            btnCancelarDetail.addEventListener("click", this.FnCallbackDetailCancelar.bind(this));
        }
        if (btnGuardarDetail != undefined) {
            //btnGuardarDetail.replaceWith(btnGuardarDetail.cloneNode(true));
            btnGuardarDetail.removeEventListener("click", this.FnCallbackDetailGuardar.bind(this));
            btnGuardarDetail.addEventListener("click", this.FnCallbackDetailGuardar.bind(this));
        }

        let fechaEnvio = document.querySelector("#fechaEnvioDetail");
        if (fechaEnvio != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaEnvioDetail");

        let fechaRespuesta = document.querySelector("#fechaRespuestaDetail");
        if (fechaRespuesta != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaRespuestaDetail");

        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general input.text-control");
        eMASReferencialJs.setearInputsEventsEnFormulario(".form-general textarea.text-control");

        let arr = [];
        arr.push({
            key: this.dsrTipoTopografia, ctrl: "tipoTopografiaDetail", ruta: "Comodatos/SMC50002/GetDataDsrGeneric"
            , fnCallback2: eMASReferencialJs.ConsultPosLlenarComboGeneric
            , parameter1: "tipoTopografiaDetail"
            , parameter2: "IdTipoTipografiaDetail"
        });
        eMASReferencialJs.CargarCombosGenerico(arr);
    }
    FnCallbackBtnNuevo(evt) {
        this.FnEditarElemento("Agregar Registro");
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
            strTitulo = "Actualizar Registro";
        else
            strTitulo = titulo;

        eMASReferencialJs.mostrarPopupDetail(strTitulo, "Comodatos/SMC50002/EditDetailView"
            , dataBody, this.FnCallbackBtnNuevoSuccess.bind(this));
    }
    FnListarAll() {
        let dataBody = {
            idtramite: this.idTramite,
            entidad: this.name
        };
        // Consultar
        eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetListDetail"
            , dataBody, this.fillDataResponse.bind(this), eMASReferencialJs.FnGeneralVacia, "");
    }
    BindearEventosCabecera() {
        let btnNuevo = document.querySelector(".container-topografia-detail button.nuevo-detail");
        if (btnNuevo != undefined) {
            btnNuevo.addEventListener("click", this.FnCallbackBtnNuevo.bind(this), false);
        }
        let btnRefresh = document.querySelector(".container-topografia-detail button.refresh-detail");
        if (btnRefresh != undefined) {
            btnRefresh.addEventListener("click", this.FnListarAll.bind(this), false);
        }
    }
    fillDataResponse(response) {
        let DataDetail = $(".container-topografia-detail table");
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
                    columns: [{}, {}, {}, {}, {}]
                });
            return;
        }
        let data = [];

        for (let i = 0; i < response.dataresult.length; i++) {
            data.push({
                tipo: response.dataresult[i].tipotopografiaterreno,
                oficio: response.dataresult[i].oficio,
                oficiorespuesta: response.dataresult[i].oficiorespuesta,
                id: response.dataresult[i].idtopografiaterreno
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
                    let strFnButtons = '<button type="button" onclick="objSMC50002.BtnEditRowItemDetail(' + row.id + ',\'Topografia\' );" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button>';
                    //strFnButtons += '<button type="button" onclick="objSMC50002.BtnDeleteRowItemDetail(' + row.id + ',\'Topografia\' );" title="Eliminar" class=\'btn btn-outline-primary \'><i class="fa fa-trash"></i></button>';
                    return strFnButtons;
                }
            },
                {}, {}, {}]
        });
    }
    nameEntity() {
        return "Topografia";
    }
}