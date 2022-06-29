const STC50001 = function () {
    const nameConsult1 = "beneficiarios";
    const nameEditAction = "EditView";
    const nameSaveAction = "EditSave";
    const nameDeleteAction = "EditDelete";
    const nameArea = "Comodatos";
    const nameController = "STC50001";

    const fnRespuestaEliminarRegistro = function (response) {
        if (response == null || response == undefined) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No se obtuvo una respuesta correcta del Aplicativo.");
            return;
        }
        if (response.tipo != "EXITO") {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.mensaje);
            return;
        } else {
            eMASReferencialJs.SetearMensajeDefaultExito("Se eliminó el registro con éxito.");
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
            eMASReferencialJs.SetearMensajeDefaultExito("Se guardó el registro con éxito.");
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
            console.log("No se encontró la clave interna CLAVEID.");
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

    const EvtCancelarFormulario = function () {
        eMASReferencialJs.FormSetVisibilityPanel(true);
        eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios")
        fnDestruirFormularioEdicion();
    };

    const EvtRegresarFormulario = function () {
        eMASReferencialJs.FormSetVisibilityPanel(true, "DataListadoBeneficiarios");
        eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios")
        fnDestruirFormularioEdicion();
    };

    const EvtGuardarFormulario = function () {
        fnGuardarRegistro();
    };

    const EvtEliminarFormularo = function () {
        fnEliminarRegistro();
    };

    const fnSetearEvtFormulario = function () {
        eMASReferencialJs.SetearEvtFormularioGenerico(EvtRegresarFormulario, EvtCancelarFormulario, EvtGuardarFormulario, EvtEliminarFormularo);
    };

    const fnDestruirFormularioEdicion = function () {
        let frmEdit = document.querySelector('.form-edit-container')
        while (frmEdit.firstChild) frmEdit.removeChild(frmEdit.firstChild);
    };

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
            // Inicializar eventos formulario edicion
            fnSetearEvtFormulario();
        }
        else {
            eMASReferencialJs.FormSetVisibilityPanel(true);
            eMASReferencialJs.FormSetVisibilityConsult(true, "DataListadoBeneficiarios")
            fnDestruirFormularioEdicion();
            eMASReferencialJs.SetearMensajeDefaultAdvertencia(response.message);
        }

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
        }, function () { eMASReferencialJs.ocultarProgress(); });
    };

    const fnGetDataFilter = function () {
        let _name = document.getElementById("name").value;
        let _representativeName = document.getElementById("representative-name").value;
        let _ruc = document.getElementById("ruc").value;
        let _contacto = document.getElementById("contacto").value;

        let dataFilter = {
            nombre: _name,
            representante: _representativeName,
            ruc: _ruc,
            contacto: _contacto
        };
        let sData = JSON.stringify(dataFilter);

        return sData;
    };

    const EvtClickEditarElemento = function (e, row, $element) {
        let codigoB = row['id'];
        fnEditarElemento(codigoB);
    };

    const SetearEventosDataGridListado = function () {
        $('#DataListadoBeneficiarios').off('click-row.bs.table').on('click-row.bs.table', EvtClickEditarElemento);
    };

    const fnPagedDataFromControllerListBeneficiarios = function (response) {
        
        $("#pagineoListadoBeneficiarios").empty();
        if (response == null || response == undefined) {
            console.log("No hay datos Listado (0)");
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }
        if (response.dataresult == null || response.dataresult == undefined) {
            console.log("No hay datos Listado (1)");
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }
        if (response.dataresult.data == null || response.dataresult == undefined) {
            console.log("No hay datos Listado (2)");
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }
        
        let DataInfoConsult = $("#" + response.dataresult.resultcontainer);
        DataInfoConsult.bootstrapTable('destroy');
        DataInfoConsult.bootstrapTable();
        let data = [];

        if (response.dataresult.data.length == 0) {
            eMASReferencialJs.SetearMensajeDefaultAdvertencia("No hay datos para la consulta seleccionada.");
            return;
        }

        for (let i = 0; i < response.dataresult.data.length; i++) {
            data.push({
                nombre: response.dataresult.data[i].nombre,
                ruc: response.dataresult.data[i].ruc,
                representante: response.dataresult.data[i].representante,
                contacto: response.dataresult.data[i].contacto,
                id: response.dataresult.data[i].id
            });
        }
        DataInfoConsult.bootstrapTable("load", data);
        SetearEventosDataGridListado();
            
        eMASReferencialJs.SetearPlantillaPagineo("objSTC50001.BtnConsultar", "pagineoListadoBeneficiarios", response.dataresult.totalpaginas, response.dataresult.paginaactual);

        let _consultLs = document.querySelector(".consult-ls");
        _consultLs.style.display = "";
        $("#panelFilterBeneficiario").collapse("hide");
        
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
            resultContainer: "DataListadoBeneficiarios",
            numeroPagina: numeroPagina
        };
        eMASReferencialJs.Ajax({
            type: "POST",
            data: djson,
            url: url,
            beforeSend: function (response) {
                eMASReferencialJs.mostrarProgress();
            },
            success: fnPagedDataFromControllerListBeneficiarios
        }, function () { eMASReferencialJs.ocultarProgress(); });
    };

    const fnLimpiarFormularioPanel = function () {
        eMASReferencialJs.LimpiarControlesHtml(".ctrl-panelFilterForm");
    };

    const fnLimpiarConsulta = function () {
        let DataInfoConsult = $("#DataListadoBeneficiarios");
        DataInfoConsult.bootstrapTable('destroy');
        DataInfoConsult.bootstrapTable();
    };

    const EvtBtnConsultar = function () {
        fnBtnConsultar(1);
    }

    const EvtBtnLimpiarFormPanel = function () {
        fnLimpiarFormularioPanel();
        fnLimpiarConsulta();
    }

    const EvtBtnNuevo = function () {
        console.log("click1");
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
        }, function () { eMASReferencialJs.ocultarProgress(); });
    }

    const inicializacionPanel = function () {
        eMASReferencialJs.InicializarPanelGenerico("panelFilterBeneficiario", EvtBtnNuevo, EvtBtnLimpiarFormPanel, EvtBtnConsultar);
    };

    return {
        InicializacionPanel: function () {
            inicializacionPanel();
        },
        BtnConsultar: function (numeroPagina) {
            fnBtnConsultar(numeroPagina);
        }
    };
}

var objSTC50001 = new STC50001();