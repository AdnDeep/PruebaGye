
const SMC50002 = function () {
    const nameConsult1 = "tramites";
    const nameEditAction = "EditView";
    const nameSaveAction = "EditSave";
    const nameDeleteAction = "EditDelete";
    const nameArea = "Comodatos";
    const nameController = "SMC50002";
    const dsrTipoContrato = "DSRTIPOCONTRATO";
    const dsrBeneficiarios = "DSRBENEFICIARIOS";
    const dsrEstados = "DSRESTADOSTRAMITES";

    const fnEliminarDetalleExito = function (entidad, mensaje) {
        if (entidad == "" || entidad == null || entidad == undefined) {
            console.error("La entidad eliminada es incorrecta");
            return;
        }
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite == 0)
            return;
        let objDetail = new GenericDetail(idTramite, 0, entidad);
        objDetail.GetListAll();
        setTimeout(() => {
            eMASReferencialJs.SetearMensajeDefaultExito(mensaje);
        }, 200);
    }

    const fnGuardaDetalleExito = function (entidad, mensaje) {
        if (entidad == "" || entidad == null || entidad == undefined) {
            console.error("La entidad actualizada es incorrecta");
            return;
        }
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite == 0)
            return;
        let objDetail = new GenericDetail(idTramite, 0, entidad);
        objDetail.GetListAll();
        setTimeout(() => {
            eMASReferencialJs.SetearMensajeDefaultExito(mensaje);
        }, 200);
        
    };

    const fnRespuestaEliminarRegistro = function (response) {
        //eMASReferencialJs.ocultarProgress();
        
        if (response == null || response == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        } else {
            eMASReferencialJs.SetearMensajeDefaultExito("Se elimin&oacute el registro con &eacute;xito.");
            fnDestruirFormularioEdicion();

            let dataConsulta = $("#DataListadoTramites").bootstrapTable('getOptions');

            if (!(dataConsulta == null && dataConsulta == undefined)) {
                if (dataConsulta.totalRows > 0) 
                    fnBtnConsultar(1);
            }

            eMASReferencialJs.FormSetVisibilityPanel(true);
            eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoTramites");
            return;
        }
    };

    const fnEliminarRegistroConsult = function () {
        let strAccionSi = "";
        //strAccionSi += "eMASReferencialJs.ocultarMensajes();";
        //strAccionSi += "$(this).parents('.modal-dialog').parent().modal('hide');";
        strAccionSi += "objSMC50002.EliminarTramite();"
        
        let mensaje = "&#191;Est&aacute; Seguro que desea eliminar el tr&aacute;mite?";
        eMASReferencialJs.EmisionPromptWarning(mensaje, strAccionSi);
    };

    const fnEliminarRegistro = function () {
        let _id = document.getElementById("IdTramite");

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
        }, function () { eMASReferencialJs.ocultarProgress(); }, undefined, eMASReferencialJs.ocultarProgress);
    };

    const fnEliminarRegistroDetail = function (id, entidad) {
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite == 0)
            return;
        let objDetail = new GenericDetail(idTramite, id, entidad);
        objDetail.DeleteById();
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
            eMASReferencialJs.SetearMensajeDefaultExito("Se guard&oacute; el registro con &eacute;xito.");
            //fnDestruirFormularioEdicion();
            fnRespuestaGuardarRegistro2(response);
            //eMASReferencialJs.FormSetVisibilityPanel(true);
            //eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios");
            return;
        }
    };
    // Reconsulta en caso de Actualizaciones o datos
    const fnRespuestaGuardarRegistro2 = function (response) {
        let responseMensajes = response.mensajes;
        let objInsertado = responseMensajes.find(eMASReferencialJs.EncontrarMensaje, { codigo: "INSERTADO" });

        if (objInsertado == undefined || objInsertado == null) {
            let idTransactionUpdated = document.getElementById("IdTramite");
            if (idTransactionUpdated != undefined) {
                fnDestruirFormularioEdicion();
                fnEditarElemento(idTransactionUpdated.value);
            }
        } else if (!(objInsertado.descripcion == null || objInsertado.descripcion == undefined)) {
            let idTransaction = parseInt(objInsertado.descripcion);
            if (idTransaction > 0) {
                fnDestruirFormularioEdicion();
                fnEditarElemento(idTransaction);
            }
        }        
        //if (responseMensajes == null || responseMensajes == undefined) {
        //    console.log("No hay mensajes en la respuesta.");
        //    return;
        //}
        //let objIdClave = responseMensajes.find(eMASReferencialJs.EncontrarMensaje, { codigo: "CLAVEID" });
        //if (objIdClave == undefined || objIdClave == null) {
        //    console.log("No se encontró la clave interna CLAVEID.");
        //    return;
        //}
        //if (!(objIdClave.descripcion == null || objIdClave.descripcion == undefined)) {
        //    let idclave = parseInt(objIdClave.descripcion);
        //    if (idclave > 0) {
        //        fnBtnConsultar(1);
        //    }
        //}

    };

    const fnObtieneValidaDataCliente = function () {
        let objRespuesta = { isValid: true, mensaje: "OK" };
        let arrCtrls = ["IdTramite", "anioEdit", "secuenciaEdit", "sectorEdit", "manzanaEdit"
            , "loteEdit", "divisionEdit", "phvEdit", "phhEdit", "numeroEdit", "beneficiarioEdit"
            , "oficioAgEdit", "oficioDaseEdit", "solarEdit", "fechaInspeccionEdit"
            , "oficioAprobacionEdit", "fechaAprobacionEdit", "tipoContratoEdit", "aniosPlazoEdit",
            , "fechaEscrituraEdit", "oficioRevocatoriaEdit"];
        let objTramite = new Tramite(arrCtrls);
        
        let dataRegistroJson = objTramite.ValidateDataAndGetObjWithValues( objRespuesta);
        
        return [objRespuesta, dataRegistroJson];
    };

    const fnGuardarRegistro = function () {        
        // Captura y Valida Data
        let respValidacionArr = fnObtieneValidaDataCliente();
        let valRespuesta = respValidacionArr[0];
        let dataRegistroJson = respValidacionArr[1];
        if (!valRespuesta.isValid) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(valRespuesta.mensaje);
            return;
        }

        // Envio Datos al servidor
        let _appConfig = eMASReferencialJs.ObtenerAppConfig();

        let rutaBase = _appConfig.RutaBase;
        rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
        let url = rutaBase + nameArea + "/" + nameController + "/" + nameSaveAction;

        eMASReferencialJs.Ajax({
            type: "POST",
            data: dataRegistroJson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnRespuestaGuardarRegistro
        }, function () { eMASReferencialJs.ocultarProgress(); }, undefined, eMASReferencialJs.ocultarProgress);
    };

    const EvtCancelarFormulario = function () {
        eMASReferencialJs.FormSetVisibilityPanel(true);
        eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoTramites")
        fnDestruirFormularioEdicion();
    };

    const EvtGuardarFormulario = function () {
        fnGuardarRegistro();
    };

    const EvtEliminarFormularo = function () {
        fnEliminarRegistroConsult();
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
            console.log("No hay ningún código de Registro");
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

    const EvtClickEditarElementDetail = function (id, entidad) {
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite <= 0) {
            console.error("Se produjo un error dado que el tramite no existe.");
            return;
        }
        let objAnexoDetail = new GenericDetail(idTramite, id, entidad);
        objAnexoDetail.GetById();
    };

    const EvtClickDeleteElementDetail = function (id, entidad) {
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite <= 0) {
            console.error("Se produjo un error dado que el tramite no existe.");
            return;
        }
        let strAccionSi = "";
        //strAccionSi += "eMASReferencialJs.ocultarMensajes();";
        //strAccionSi += "$(this).parents('.modal-dialog').parent().modal('hide');";
        strAccionSi += "objSMC50002.EliminarTramiteDetail(" +id +",'"+entidad+"');";
        
        let mensaje = "&#191;Est&aacute; Seguro que desea eliminar el registro?";
        eMASReferencialJs.EmisionPromptWarning(mensaje, strAccionSi);
    }

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
        ObtenerInfoBeneficiarioLegal();
        ObtenerInfoTipoContrato();
    };

    const InicializarCamposFecha = function () {
        let fechaInspecion = document.querySelector("#fechaInspeccionEdit");
        if(fechaInspecion != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaInspeccionEdit");

        let fechaAprobacion = document.querySelector("#fechaAprobacionEdit");
        if (fechaAprobacion != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaAprobacionEdit");

        let fechaEscritura = document.querySelector("#fechaEscrituraEdit");
        if (fechaEscritura != undefined)
            eMASReferencialJs.SetearFechaBootstrap("#fechaEscrituraEdit");
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
                let _representanteLegalEdit = document.querySelector("#representanteLegalEdit");
                if (_representanteLegalEdit != undefined)
                    _representanteLegalEdit.value = elementFound.value;
            }
        }
    }

    const ConsultPosLlenarCombo = function (parameter1, parameter2) {
        if (parameter1 == "beneficiarioEdit") {
            let _beneficiarioEditCtrl = document.querySelector(`#${parameter1}`);
            let _idBeneficiario = document.querySelector(`#${parameter2}`);

            if (_beneficiarioEditCtrl != undefined && _idBeneficiario != undefined) {
                eMASReferencialJs.SelectItemByValue(_beneficiarioEditCtrl, _idBeneficiario.value);
                let dataBody = { key1: "ENTIDADBENEFICIARIO", keyentity: _idBeneficiario.value, target: "representanteLegalEdit" };
                eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetDataDsrGeneric", dataBody, LlenaNombreRepresentante, eMASReferencialJs.FnGeneralVacia, "");
            }
        } else {
            let _ctrl = document.querySelector(`#${parameter1}`);
            let _idEntity = document.querySelector(`#${parameter2}`);
            if (_ctrl != undefined && _idEntity != undefined)
                eMASReferencialJs.SelectItemByValue(_ctrl, _idEntity.value);
        }
    };

    const ObtenerInfoTipoContrato = function () {
        let _idTipoContrato = document.getElementById("IdTipoContrato");
        if (_idTipoContrato <= 0) {
            console.log("No hay datos de Tipo de Contrato para recuperar");
        }
        let arr = [];
        arr.push({
            key: dsrTipoContrato, ctrl: "tipoContratoEdit", ruta: "Comodatos/SMC50002/GetDataDsrGeneric"
            , fnCallback2: ConsultPosLlenarCombo
            , parameter1: "tipoContratoEdit"
            , parameter2: "IdTipoContrato"
        });
        eMASReferencialJs.CargarCombosGenerico(arr);
    };

    const ObtenerInfoBeneficiarioLegal = function () {
        let _idBeneficiario = document.getElementById("IdBeneficiario");
        if (_idBeneficiario <= 0) {
            console.log("No hay datos de beneficiario para recuperar");
        }
        let arr = [];
        arr.push({
            key: dsrBeneficiarios, ctrl: "beneficiarioEdit", ruta: "Comodatos/SMC50002/GetDataDsrGeneric"
            , fnCallback2: ConsultPosLlenarCombo
            , parameter1: "beneficiarioEdit"
            , parameter2: "IdBeneficiario"
        });
        eMASReferencialJs.CargarCombosGenerico(arr);
    };

    const EvtCambioBeneficiario = function (event) {
        let valSelected = event.target.value;
        if (!(valSelected == null || valSelected == undefined || valSelected == "")) {
            let dataBody = { key1: "ENTIDADBENEFICIARIO", keyentity: valSelected, target: "representanteLegalEdit" };
            eMASReferencialJs.FetchPost("Comodatos/SMC50002/GetDataDsrGeneric", dataBody, LlenaNombreRepresentante, eMASReferencialJs.FnGeneralVacia, "");
        }
    };

    const EvtKeyPressSolar = function (event) {
        return eMASReferencialJs.EsDecimalConPunto(event);
    };

    const fnSetearEvtCustomizado = function () {
        let _beneficiarioEditCtrl = document.querySelector("#beneficiarioEdit");
        if (_beneficiarioEditCtrl != undefined) {
            _beneficiarioEditCtrl.addEventListener('change', EvtCambioBeneficiario);
        }
        
        let _solarEditEditCtrl = document.querySelector("#solarEdit");
        if (_solarEditEditCtrl != undefined) {
            _solarEditEditCtrl.addEventListener('keypress', EvtKeyPressSolar);
        }
    };

    const fnGetDetails = function () {
        let idTramite = document.getElementById("IdTramite").value;
        if (idTramite == 0)
            return;
        let objAnexoDetail = new GenericDetail(idTramite, 0,"Anexo");
        objAnexoDetail.GetListAll();
        objAnexoDetail.BindEventsTable();
        let objObservacionDetail = new GenericDetail(idTramite, 0, "Observacion");
        objObservacionDetail.GetListAll();
        objObservacionDetail.BindEventsTable();
    };

    const fnSetearEvtFormulario = function () {
        eMASReferencialJs.SetearEvtFormularioGenerico(EvtRegresarFormulario, EvtCancelarFormulario, EvtGuardarFormulario, EvtEliminarFormularo);
        fnSetearEvtCustomizado();
        fnGetDetails();
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
        },
        BtnEditRowItemDetail: function (id, entidad) {
            EvtClickEditarElementDetail(id, entidad);
        },
        BtnDeleteRowItemDetail: function (id, entidad) {
            EvtClickDeleteElementDetail(id, entidad);
        },
        EliminarTramite: function () {
            fnEliminarRegistro();
        },
        EliminarTramiteDetail: function (id, entidad) {
            fnEliminarRegistroDetail(id, entidad);
        },
        CallbackPosGuardarDetalleExito: function (entidad, mensaje) {
            fnGuardaDetalleExito(entidad, mensaje);
        },
        CallbackPosEliminarDetalleExito: function (entidad, mensaje) {
            fnEliminarDetalleExito(entidad, mensaje);
        }
    };
}

var objSMC50002 = new SMC50002();