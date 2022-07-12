
const SMC50002 = function () {
    const nameConsult1 = "tramites";
    const nameEditAction = "EditView";
    const nameSaveAction = "EditSave";
    const nameDeleteAction = "EditDelete";
    const nameArea = "Comodatos";
    const nameController = "SMC50002";
    const dsrBeneficiarios = "DSRBENEFICIARIOS";
    const dsrEstados = "DSRESTADOSTRAMITES";
    /*
    const fnRespuestaEliminarRegistro = function (response) {
        if (response == null || response == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        } else {
            eMASReferencialJs.SetearMensajeDefaultExito("Se elimin� el registro con �xito.");
            fnDestruirFormularioEdicion();
            fnBtnConsultar(1);
            eMASReferencialJs.FormSetVisibilityPanel(true);
            eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios");
            return;
        }
    };

    const fnRespuestaGuardarRegistro = function (response) {
        if (response == null || response == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        } else {            
            eMASReferencialJs.SetearMensajeDefaultExito("Se guard� el registro con �xito.");
            fnDestruirFormularioEdicion();
            fnRespuestaGuardarRegistro2(response.mensajes);
            eMASReferencialJs.FormSetVisibilityPanel(true);
            eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios");
            return;
        }
    };
    // Reconsulta en caso de Actualizaciones o datos
    const fnRespuestaGuardarRegistro2 = function (responseMensajes) {
        if (responseMensajes == null || responseMensajes == undefined) {
            console.log("No hay mensajes en la respuesta.");
            return;
        }
        let objIdClave = responseMensajes.find(eMASReferencialJs.EncontrarMensaje, { codigo : "CLAVEID" });
        if (objIdClave == undefined || objIdClave == null) {
            console.log("No se encontr� la clave interna CLAVEID.");
            return;
        }
        if (!(objIdClave.descripcion == null || objIdClave.descripcion == undefined)) {
            let idclave = parseInt(objIdClave.descripcion);
            if (idclave > 0) {
                fnBtnConsultar(1);
            }
        }
            
    };

    const fnGuardarRegistro = function () {
        let _id = document.getElementById("IdBeneficiario");

        let _nombreCtrl = document.getElementById("name-edit");
        let _representanteCtrl = document.getElementById("representative-name-edit");
        let _rucCtrl = document.getElementById("ruc-edit");
        let _contactoCtrl = document.getElementById("contacto-edit");

        // Validaciones

        // Envio Datos al servidor
        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/" + nameSaveAction;

        let dataRegistroJson = {
            id: _id.value,
            nombre: _nombreCtrl.value,
            representante: _representanteCtrl.value,
            ruc: _rucCtrl.value,
            contacto: _contactoCtrl.value
        };

        eMASReferencialJs.Ajax({
            type: "POST",
            data: dataRegistroJson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnRespuestaGuardarRegistro
        }, function () { eMASReferencialJs.ocultarProgress(); });
    };

    const fnEliminarRegistro = function () {
        let _id = document.getElementById("IdBeneficiario");

        // Envio Datos al servidor
        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/" + nameDeleteAction;

        let dataRegistroJson = {
            id: _id.value
        };

        eMASReferencialJs.Ajax({
            type: "POST",
            data: dataRegistroJson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnRespuestaEliminarRegistro
        }, function () { eMASReferencialJs.ocultarProgress(); });
    };




    */
    const EvtCancelarFormulario = function () {
        eMASReferencialJs.FormSetVisibilityPanel(true);
        eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoTramites")
        fnDestruirFormularioEdicion();
    };

    const EvtGuardarFormulario = function () {
        fnGuardarRegistro();
    };

    const EvtEliminarFormularo = function () {
        fnEliminarRegistro();
    };
    const EvtRegresarFormulario = function () {
        eMASReferencialJs.FormSetVisibilityPanel(true, "DataListadoTramites");
        eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoTramites")
        fnDestruirFormularioEdicion();
    };
    const fnDestruirFormularioEdicion = function () {
        let frmEdit = document.querySelector('.form-edit-container')
        while (frmEdit.firstChild) frmEdit.removeChild(frmEdit.firstChild);
    };
    const fnEditarElemento = function (id) {
        if (id == null || id == undefined) {
            console.log("No hay ning�n c�digo de Registro");
            return;
        }
        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/" + nameEditAction;
        let djson = {
            id: id,
        };
        eMASReferencialJs.Ajax({
            type: "POST",
            data: djson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnSuccessEditAction
        }, function () { eMASReferencialJs.ocultarProgress(); }, undefined, eMASReferencialJs.ocultarProgress);
    };

    const EvtClickEditarElemento = function (id) {
        let codigoB = id;
        fnEditarElemento(codigoB);
    };

    const fnGetDataFilter = function () {
        let _expAnio = document.getElementById("exp-anio").value ?? 0;
        let _expSecuencial = document.getElementById("exp-secuencial").value ?? 0;
        let _nombreBeneficiario = document.getElementById("nombre-beneficiario").value ?? 0;

        let _sector = document.getElementById("sector").value ?? 0;
        let _manzana = document.getElementById("manzana").value ?? 0;
        let _lote = document.getElementById("lote").value ?? 0;
        let _division = document.getElementById("division").value ?? 0;
        let _phv = document.getElementById("phv").value ?? 0;
        let _phh = document.getElementById("phh").value ?? 0;
        let _numero = document.getElementById("numero").value ?? 0;
        let _estado = document.getElementById("estado").value ?? 0;

        let dataFilter = {
            anioexp: _expAnio,
            secexp: _expSecuencial,
            idbeneficiario: _nombreBeneficiario,
            sector: _sector,
            manzana: _manzana,
            lote: _lote,
            division: _division,
            phv: _phv,
            phh: _phh,
            numero: _numero,
            idestado: _estado
        };
        let sData = JSON.stringify(dataFilter);

        return sData;
    };

    const fnInicializarInformacionRelacionada = function () {
        InicializarCamposFecha();
        ObtenerRepresentanteLegal();
    };

    const InicializarCamposFecha = function () {
        let fechaInspecion = document.querySelector("#fecha-inspeccion-edit");
        if(fechaInspecion != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fecha-inspeccion-edit");

        let fechaAprobacion = document.querySelector("#fecha-aprobacion-edit");
        if (fechaAprobacion != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fecha-aprobacion-edit");
    };

    const LlenaNombreRepresentante = function (data) {
        if (data == null || data == undefined) {
            console.log("Respuesta incorrecta del servidor Data Entidad (1)");
            return;
        }
        if (data.key == null || data.key == undefined || data.key == ""
            || data.target == null || data.target == undefined || data.target == "") {
            console.log("Respuesta incorrecta del servidor Data Entidad (2)");
            return;
        }
        if (data.key == "ERROR") {
            console.log(data.target);
            return;
        }
        if (!(data.datasource == null || data.datasource == undefined)) {
            let elementFound = data.datasource.find(element => element.key === "NOMBREREPRESENTANTE");
            if (!(elementFound == null || elementFound == undefined)) {
                let _representanteLegalEdit = document.querySelector("#representante-legal-edit");
                if (_representanteLegalEdit != undefined)
                    _representanteLegalEdit.value = elementFound.value;
            }
        }
    }

    const ConsultPosLlenarCombo = function (parameter1) {
        debugger;
        if (parameter1 == "beneficiario-edit") {
            let _beneficiarioEditCtrl = document.querySelector("#beneficiario-edit");
            let _idBeneficiario = document.querySelector("#IdBeneficiario");

            if (_beneficiarioEditCtrl != undefined && _idBeneficiario != undefined) {
                eMASReferencialJs.SelectItemByValue(_beneficiarioEditCtrl, _idBeneficiario.value);
                let dataBody = { key1: "ENTIDADBENEFICIARIO", keyentity: _idBeneficiario.value, target: "representante-legal-edit" };
                eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetDataDsrGeneric", dataBody, LlenaNombreRepresentante, eMASReferencialJs.FnGeneralVacia, "");
            }
        }
    };

    const ObtenerRepresentanteLegal = function () {
        let _idBeneficiario = document.getElementById("IdBeneficiario");
        if (_idBeneficiario <= 0) {
            console.log("No hay datos de beneficiario para recuperar");
        }
        let arr = [];
        arr.push({
            key: dsrBeneficiarios, ctrl: "beneficiario-edit", ruta: "Comodatos/SMC50002/GetDataDsrGeneric"
            , fnCallback2: ConsultPosLlenarCombo
            , parameter1:"beneficiario-edit"
        });
        eMASReferencialJs.CargarCombosGenerico(arr);
    };

    const EvtCambioBeneficiario = function (event) {
        let valSelected = event.target.value;
        if (!(valSelected == null || valSelected == undefined || valSelected == "")) {
            let dataBody = { key1: "ENTIDADBENEFICIARIO", keyentity: valSelected, target: "representante-legal-edit" };
            eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetDataDsrGeneric", dataBody, LlenaNombreRepresentante, eMASReferencialJs.FnGeneralVacia, "");
        }

    };

    const fnSetearEvtCustomizado = function () {
        let _beneficiarioEditCtrl = document.querySelector("#beneficiario-edit");
        if (_beneficiarioEditCtrl != undefined) {
            _beneficiarioEditCtrl.addEventListener('change', EvtCambioBeneficiario);
        }
    };

    const fnSetearEvtFormulario = function () {
        eMASReferencialJs.SetearEvtFormularioGenerico(EvtRegresarFormulario, EvtCancelarFormulario, EvtGuardarFormulario, EvtEliminarFormularo);
        fnSetearEvtCustomizado();
    };

    const fnPagedDataFromControllerListTramites = function (response) {
        $("#pagineoListadoTramites").empty();
        if (response == null || response == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("Se ha producido un error en el aplicativo {1}.");
            return;
        }
        if (response.tipo !== "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        }
        if (response.dataresult == null || response.dataresult == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }
        

        let DataInfoConsult = $("#" + response.dataresult.resultcontainer);
        DataInfoConsult.bootstrapTable('destroy');
        let data = [];
        if (response.dataresult.data == null || response.dataresult == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }
        if (response.dataresult.data.length == 0) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }

        for (let i = 0; i < response.dataresult.data.length; i++) {
            data.push({
                anioexp: response.dataresult.data[i].anioexp,
                secexp: response.dataresult.data[i].secexp,
                beneficiario: response.dataresult.data[i].beneficiario,
                ruc: response.dataresult.data[i].ruc,
                codigocatastral: response.dataresult.data[i].codigocatastral,
                id: response.dataresult.data[i].id
            });
        }

        DataInfoConsult.bootstrapTable({
            data: data,
            columns: [{
                field: 'actions',
                title: 'Acciones',
                align: 'center',
                valign: 'middle',
                clickToSelect: false,
                formatter: function (value, row, index) {
                    return '<button type="button" onclick="objSMC50002.BtnEditRowItem(' + row.id + ');" title="Editar" class=\'btn btn-outline-primary \'><i class="fa fa-pencil-square-o"></i></button> ';
                }
            }, {}, {}, {}, {}, {}, {}]
        });

        eMASReferencialJs.SetearPlantillaPagineo("objSMC50002.BtnConsultar", "pagineoListadoTramites", response.dataresult.totalpaginas, response.dataresult.paginaactual);

        let _consultLs = document.querySelector(".consult-ls");
        _consultLs.style.display = "";
        $("#panelFilterTramite").collapse("hide");

    };

    const fnBtnConsultar = function (numeroPagina) {
        let dataFilter = fnGetDataFilter();

        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/GetPagedData";
        let djson = {
            data: dataFilter,
            typeSearch: nameConsult1,
            resultContainer: "DataListadoTramites",
            numeroPagina: numeroPagina
        };
        eMASReferencialJs.Ajax({
            type: "POST",
            data: djson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnPagedDataFromControllerListTramites
        }, function () { eMASReferencialJs.ocultarProgress(); }, undefined, eMASReferencialJs.ocultarProgress);
    };

    const EvtBtnConsultar = function () {
        fnBtnConsultar(1);
    }

    const fnSuccessEditAction = function (response) {
        if (response == undefined || response == null) {
            console.error("Se produjo error consumiendo ajax.");
            return;
        }

        let _formContent = document.querySelector(".form-edit-container");

        if (response.cancontinue) {
            eMASReferencialJs.FormSetVisibilityPanel(false);
            eMASReferencialJs.FormSetVisibilityConsult(false);
            _formContent.appendChild(eMASReferencialJs.htmlToElement(response.content));

            fnInicializarInformacionRelacionada();

            fnSetearEvtFormulario();
        }
        else {
            eMASReferencialJs.FormSetVisibilityPanel(true);
            eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoTramites")
            fnDestruirFormularioEdicion();
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.message);
        }
    };

    const SetearValoresInicialesFormulario = function () {
        let num_anio = document.querySelector("#exp-anio");
        num_anio.value = "2022";
    };

    const fnLimpiarFormularioPanel = function () {
        eMASReferencialJs.LimpiarControlesHtml(".ctrl-panelFilterForm");
        SetearValoresInicialesFormulario();
    };

    const EvtBtnLimpiarFormPanel = function () {
        fnLimpiarFormularioPanel();
        fnLimpiarConsulta();
    }

    const fnLimpiarConsulta = function () {
        let DataInfoConsult = $("#DataListadoTramites");
        DataInfoConsult.bootstrapTable('destroy');
        DataInfoConsult.bootstrapTable();
    };

    const EvtBtnNuevo = function () {
        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/" + nameEditAction;
        let djson = {
            id: 0,
        };
        eMASReferencialJs.Ajax({
            type: "POST",
            data: djson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnSuccessEditAction
        }, function () { eMASReferencialJs.ocultarProgress(); }, undefined, eMASReferencialJs.ocultarProgress);
    }

    const cargaDatosCombosPanel = function () {
        let arr = [];

        arr.push({ key: dsrBeneficiarios, ctrl: "nombre-beneficiario", ruta: "Comodatos/SMC50002/GetDataDsrGeneric", fnCallback2: eMASReferencialJs.FnGeneralVacia});
        arr.push({ key: dsrEstados, ctrl: "estado", ruta: "Comodatos/SMC50002/GetDataDsrGeneric", fnCallback2: eMASReferencialJs.FnGeneralVacia});
        eMASReferencialJs.CargarCombosGenerico(arr);
    };

    const inicializacionPanel = function () {
        eMASReferencialJs.InicializarPanelGenerico("panelFilterTramite", EvtBtnNuevo, EvtBtnLimpiarFormPanel, EvtBtnConsultar, "DataListadoTramites");
        // Carga Datos Comboboxes
        cargaDatosCombosPanel();
    };

    return {
        InicializacionPanel: function () {
            inicializacionPanel();
        },
        BtnConsultar: function (numeroPagina) {
            fnBtnConsultar(numeroPagina);
        },
        BtnEditRowItem: function (id) {
            EvtClickEditarElemento(id);
        }
    };
}

var objSMC50002 = new SMC50002();