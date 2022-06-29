
function eMASReferencialJs() { };

eMASReferencialJs.serverPath = "";
eMASReferencialJs.instrumentationKey = "";

eMASReferencialJs.tipoMensaje = {
    Exito: 0,
    Error: 1,
    Advertencia: 2,
    Prompt: 3,
    Contrato: 4
};
eMASReferencialJs.Advertencia = {
    Titulo: "Advertencia"
};
eMASReferencialJs.Informativo = {
    Titulo: "Informativo"
};
eMASReferencialJs.Exito = {
    Titulo: "Exito"
};
eMASReferencialJs.tipoPersona = {
    Empleado: 1,
    Familiar: 2
};

eMASReferencialJs.EstadoEmpleado = {
    PreIngreso: 1,
    Activo: 2,
    Inactivo: 3,
    Suspendido: 4
};

eMASReferencialJs.TipoPermiso = {
	PermisoEnDias: 14,
	PermisoEnHoras: 15
};

eMASReferencialJs.EstadoCeseFuncion = {
    Ingresado: 18,
    Reversado: 19
};

eMASReferencialJs.EstadoCurso = {
    Iniciado: 22,
    Finalizado: 23
};

eMASReferencialJs.TipoEmpleado = {
    Aspirante: 1,
    Empleado: 2,
    Jubilado: 3,
    ConcejalSuplente: 4
};

eMASReferencialJs.ModalidadContratacion = {
    ContratoOcasional: 1,
    ContratoOcasionalNJS: 2,
    NombramientoPermanente: 3,
    NombramientoProvisional: 4,
    NombramientoLibreRemocion: 5
};

eMASReferencialJs.TipoContrato = {
    Indefinido: 1,
    Personalizado: 2
};

eMASReferencialJs.TipoAccionPersonal = {
    Ingreso: 1,
    Reingreso: 2,
    Ascenso: 3,
    Traslado: 4,
    Nombramiento: 5,
    Sancion: 6,
    Destitucion: 7,
    Subrogacion: 8,
    Encargo: 9,
    Vacaciones: 10,
    Comision: 11,
    Licencia: 12,
    CambioAdministrativo: 13,
    Reclasificacion: 14,
    Revalorizacion: 15,
    CambioDenominacion: 16,
    Renuncia: 17,
    SupresionPuesto: 18,
    Jubilacion: 19,
    Fallecimiento: 20,
    Remoción: 21,
    CompraRenuncia: 22
};

eMASReferencialJs.TipoModalidad = {
    Contratacion: 1,
    Nombramiento: 2
};

eMASReferencialJs.TipoTurnoDia = {
    Laborable: 3,
    DescansoObligatorio: 4
};

eMASReferencialJs.TipoDiaCalendario = {
	DiaNormal: 5,
	Feriado: 6,
	DiaRecuperablePorFeriado: 7
};

eMASReferencialJs.TramitesRecursosHumanos = {
    Contrato: 1,
    NovedadAsistencia: 2,
    Sobretiempo: 3,
    LiquidacionHaber: 4
};

eMASReferencialJs.FlujoLiquidacionHaber = {
	LiquidacionGeneradaPreliminar: 1,
	LiquidacionAnulada: 2,
	LiquidacionModificadaAsistente: 3,
	LiquidacionAprobadaAsistente: 4,
	LiquidacionRetornadaJefe: 5,
	LiquidacionAprobadaJefe: 6,
	LiquidacionOficiadaDireccionFinanciera: 7
};

eMASReferencialJs.FlujoSobretiempo = {
    SolicitudIniciadaPorElEmpleado: 8,
    SolicitudFinalizadaPorElEmpleado: 9,
    SolicitudAprobadaPorElSupervisor: 10,
    SolicitudRetornadaAlEmpleado: 11,
    SolicitudAprobadaPorElJefe: 12,
    SolicitudRetornadaPorElJefe: 13,
    SolicitudAprobadaPorElDirector: 14,
    SolicitudRetornadaPorElDirector: 15,
    SolicitudAprobadaParaPago: 16,
    SolicitudRetornadaPorRemuneraciones: 17,
    SolicitudAnulada: 18
};

eMASReferencialJs.FlujoNovedadAsistencia = {
	SolicitudIniciadaPorElEmpleado: 19,
	SolicitudAprobadaPorElJefe: 20,
	SolicitudRetornadaPorElJefe: 21,
	SolicitudAprobadaPorElDirector: 22,
	SolicitudRetornadaPorElDirector: 23,
	SolicitudAprobadaPorRrhh: 24,
	SolicitudRetornadaPorRrhh: 25,
	SolicitudAnulada: 26
};

eMASReferencialJs.Error = {
    ErrorGeneral: 'Se presento un error en la aplicación, por favor comuniquese con la Dirección de Informática.',
    ErrorPlanificacionCargo: 'No podra actualizar el registro porque existe al menos un empleado asignado en la planificación.',
    ErrorFaltaIdentificacion: 'Debe escribir un número de identificación para buscar.',
    ErrorPerderCambios: 'Se perderan todos los cambios realizados </br> ¿Desea continuar?'
};

eMASReferencialJs.botonAceptar = {
    Nombre: "Aceptar",
    Accion: "$(this).parents('.modal-dialog').parent().modal('hide');"
};

eMASReferencialJs.botonNo = {
    Nombre: "No",
    Accion: "$(this).parents('.modal-dialog').parent().modal('hide');"
};

eMASReferencialJs.mostrarProgress = function () {
    $("#loaderGif").show();
};

eMASReferencialJs.ocultarProgress = function () {
    $("#loaderGif").hide();
};

eMASReferencialJs.mostrarPopup = function (titulo, url, funcionCargar, funcionCerrar) {
    var popup = $("#VentanaPopup").clone().appendTo("#Popups");
    popup.find('.modal-title').html(titulo);
    popup.find('.modal-content').css('border', '1px solid #4f6d81');
    popup.find('.modal-header').css('background', '#fff url("../Referencial/Images/prompt_header.gif") repeat-x');
    popup.find('.modal-header').css('background-size', 'cover');
    popup.find('.modal-header').css('color', '#355468');
    popup.find('.modal-footer').empty();
    popup.find('.modal-footer').css('background', 'none');
    popup.find('.modal-footer').css('border', 'none');

    $.get(url, function (data) {
        popup.find('.modal-body').html(data);
        funcionCargar();
    });

    popup.modal('show');

    popup.on('hidden.bs.modal', function () {
        funcionCerrar();
        popup.html('');
    });
};

eMASReferencialJs.generarBoton = function (nombre, accion) {
    var boton = new Object();
    boton.Nombre = nombre;
    boton.Accion = accion;

    return boton;
};

eMASReferencialJs.mostrarMensajes = function (titulo, tipoMensaje, mensajes, botones) {
    var popup = $("#VentanaMensajes");

    popup.find('.modal-header').html(titulo).css('fontWeight', 'bold');

    var contenidoMensaje = popup.find('.modal-body');
    contenidoMensaje.html('');
    for (var item in mensajes) {
        contenidoMensaje.append(mensajes[item].Description + '<br>');
    }

    var contenidoBotones = popup.find(".modal-footer");
	contenidoBotones.html('');
	popup.find('.modal-content').css('background', 'white');
	popup.find('.modal-header').css('color', '#000');
	//popup.find('.modal-header').css('background', 'white');
	//popup.find('.modal-body').css('background', 'white');
	popup.find('.modal-body').css('color', '#000');
	popup.find('.modal-body').css('min-height', '80px');
	popup.find('.modal-footer').css('background-color', 'transparent');
	popup.find('.modal-footer').css('display', 'unset');


    if (tipoMensaje === eMASReferencialJs.tipoMensaje.Exito) {
        popup.find('.modal-content').css('border', '1px solid #60a174');
		popup.find('.modal-header').css('background', '#e6f1e9 url("' + eMASReferencialJs.serverPath + 'Referencial/Images/success50.png") no-repeat right center');
        for (var itemS in botones) {
			contenidoBotones.append('<a class="btn btn-sm btnSuccess" href="#" onclick="' + botones[itemS].Accion + '">' + botones[itemS].Nombre + '</a>');
        }
    }
    else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Error) {
        popup.find('.modal-content').css('border', '1px solid #924949');
		popup.find('.modal-header').css('background', '#f2e4e4 url("' + eMASReferencialJs.serverPath + 'Referencial/Images/error50.png") no-repeat right center');
        for (var itemE in botones) {
            contenidoBotones.append('<a class="btn btn-sm btnError" href="#" onclick="' + botones[itemE].Accion + '">' + botones[itemE].Nombre + '</a>');
        }
    }
    else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Advertencia) {
        popup.find('.modal-content').css('border', '1px solid #c5a524');
		popup.find('.modal-header').css('background', '#fffcd9 url("' + eMASReferencialJs.serverPath + 'Referencial/Images/warning50.png") no-repeat right center');

        for (var itemA in botones) {
			contenidoBotones.append('<a class="btn btn-sm btnWarning" href="#" onclick="' + botones[itemA].Accion + '">' + botones[itemA].Nombre + '</a>');
        }
    }
    else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Prompt) {
		popup.find('.modal-content').css('border', '1px solid #5b4f4f');
		popup.find('.modal-header').css('background', '#d5d8da url("' + eMASReferencialJs.serverPath + 'Referencial/Images/prompt50.png") no-repeat right center');
		for (var itemP in botones) {
			if (botones[itemP].Nombre === 'Si')
				contenidoBotones.append('<a class="btn btn-sm btnSi" href="#" onclick="' + botones[itemP].Accion + '">' + botones[itemP].Nombre + '</a>');
			else if (botones[itemP].Nombre === 'No')
				contenidoBotones.append('<a class="btn btn-sm btnNo" href="#" onclick="' + botones[itemP].Accion + '">' + botones[itemP].Nombre + '</a>');
			else
				contenidoBotones.append('<a class="btn btn-sm" style="background:#fff url(' + eMASReferencialJs.serverPath + 'Referencial/Images/prompt_header.gif) repeat-x; color: #6C6767; border:1px solid #5b4f4f; padding: 0rem 0.5rem;" href="#" onclick="' + botones[itemP].Accion + '">' + botones[itemP].Nombre + '</a>');
        }
    }
	else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Contrato) {
		popup.find('.modal-header').css('background', '#93d9e4');
        for (var itemC in botones) {
            contenidoBotones.append('<a class="' + botones[item].Clase + '" href="#" onclick="' + botones[itemC].Accion + '">' + botones[itemC].Nombre + '</a>');
        }
    }    

    popup.modal({
        "backdrop": "static",
        "keyboard": false,
        "show": true
    });

    popup.on('hidden.bs.modal', function () {
        funcionCerrar();
        popup.find('.modal-header').html('');
        popup.find('.modal-body').html('');
        popup.find('.modal-footer').html('');
    });
};



eMASReferencialJs.mostrarPanelMensajes = function (tipoMensaje, mensajes) {
    var popup = $('#DocumentoTramiteSolicitud').parents('.modal-dialog').parent().find('.modal-footer');

    popup.empty();

    for (var item in mensajes) {
        popup.append(mensajes[item].Description + '<br>');
    }

    if (tipoMensaje === eMASReferencialJs.tipoMensaje.Exito) {
        popup.css('background', '#fff url("' + eMASReferencialJs.serverPath + 'Referencial/Images/success_header.gif") repeat-x');
        popup.css('color', '#3c7f51');
        popup.css('border', '1px solid #60a174');
    }
    else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Error) {
        popup.css('background', '#fff url("' + eMASReferencialJs.serverPath + 'Referencial/Images/error_header.gif") repeat-x');
        popup.css('color', '#6f2c2c');
        popup.css('border', '1px solid #924949');
    }
    else if (tipoMensaje === eMASReferencialJs.tipoMensaje.Advertencia) {
        popup.css('background', '#fff url("' + eMASReferencialJs.serverPath + 'Referencial/Images/warning_header.gif") repeat-x');
        popup.css('color', '#957c17');
        popup.css('border', '1px solid #c5a524');
    }

    popup.css('background-size', 'cover');
    popup.css('text-align', 'justify');
    popup.css('font-size', '13px');
    popup.css('font-weight', 'bold');
    popup.css('padding', '5px');
};

function funcionCerrar() { }

eMASReferencialJs.generateBuscador = function (buscador, nombreBuscador, nombreBtnBuscador, required, classInput, maxLength) {
    buscador.addClass('input-group');
    buscador.css('width', '100%');
	var strRequired = required ? "required" : "";
	var strMaxLength = maxLength === null || maxLength === undefined || maxLength === '' ? '' : 'maxlength="' + maxLength + '"';
	if (classInput === null || classInput === undefined || classInput === "") {
		buscador.append('<input type="text" class="form-control nopegar noAceptaCaracterEspecial" name="' + nombreBuscador + '" ' + strRequired + ' ' + strMaxLength + ' />');
	}
	else {
		buscador.append('<input type="text" class="form-control ' + classInput + '" name="' + nombreBuscador + '" ' + strRequired + ' ' + strMaxLength + ' />');
	}
    buscador.append('<div class="input-group-append"><button type="button" class="btn btnBuscar" id="' + nombreBtnBuscador + '" name="' + nombreBtnBuscador + '"><i class="fa fa-search"></i></button></div>');
    if (required) {
        buscador.append('<div class="invalid-feedback">Campo requerido.</div>');
    }
    return buscador;
};

////////////////////////////// BUSCADOR //////////////////////////////

/*Crea el componente del buscador*/
eMASReferencialJs.GenerarComponenteBuscador = function (buscador, nombre, requerido) {
    buscador.addClass('input-group');
    buscador.css('width', '100%');
    buscador.append('<input type="text" class="form-control" name="' + nombre + '" ' + requerido ? "required" : "" + '>');
    buscador.append('<div class="input-group-append"><button type="button" class="btn btnBuscar" name="button' + nombre + '"><i class="fa fa-search"></i></button></div>');
    if (requerido) {
        buscador.append('<div class="invalid-feedback">Campo requerido.</div>');
    }
    return buscador;
};

/////////////////////////// EVENTO Y ACCIÓN //////////////////////////

/*Bloquea a los componentes el evento pegar*/
eMASReferencialJs.EventoNoPegar = function () {
    $(".nopegar").bind("paste", function (event) {
        event.preventDefault();
    });
};

/*Permite a los componentes aceptar solo valores enteros*/
eMASReferencialJs.EventoAceptaValorEntero = function () {
    $(".aceptaValorEntero").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^\d].+/, ""));
        if (event.which !== 0 && event.which !== 8 && (event.keyCode < 37 || event.keyCode > 40) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
};

/*Permite a los componentes aceptar solo valores decimales (18,4)*/
eMASReferencialJs.EventoAceptaValorDecimal = function () {
    $(".aceptaValorDecimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if (event.which !== 0 && event.which !== 8 && (event.keyCode < 37 || event.keyCode > 40) && (event.which !== 46 || $(this).val().indexOf('.') !== -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
        else if (event.which >= 48 && event.which <= 57) {
            var value = $(this).val() + String.fromCharCode(event.which);
            if (parseFloat(value) < 0 || parseFloat(value) > 99999999999999 || value.substring(value.indexOf(".") + 1, value.indexOf(".") !== -1 ? value.length : 0).length > 4) {
                event.preventDefault();
            }
        }
    });
};

/*Permite a los componentes aceptar solo valores decimales en un rango [0-100]*/
eMASReferencialJs.EventoAceptaRangoValorDecimal = function () {
    $(".aceptaRangoValorDecimal").on("keypress keyup blur", function (event) {
        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
        if (event.which !== 0 && event.which !== 8 && (event.keyCode < 37 || event.keyCode > 40) && (event.which !== 46 || $(this).val().indexOf('.') !== -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
        else if (event.which >= 48 && event.which <= 57) {
            var value = $(this).val() + String.fromCharCode(event.which);
            if (parseFloat(value) < 0 || parseFloat(value) > 100 || value.substring(value.indexOf(".") + 1, value.indexOf(".") !== -1 ? value.length : 0).length > 2) {
                event.preventDefault();
            }
        }
    });
};

/*Devuelve un mensaje unificado de una lista de mensajes*/
eMASReferencialJs.FormarMensaje = function (mensajes) {
    var mensaje = "";
	for (var i = 0; i < mensajes.length; i++) {
		if (mensajes.length === 1) {
			mensaje += mensajes[i];
		}
        else if (i !== mensajes.length - 1) {
            mensaje += "* " + mensajes[i] + "<br>";
        }
        else {
            mensaje += "* " + mensajes[i];
        }
    }
    return mensaje;
};

/*Devuelve un objeto json con los datos serializados de un formulario*/
$.fn.serializeFormJSON = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        }
        else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

//////////////////////////// FECHA Y HORA ////////////////////////////

/*Crea el componente de la fecha y hora*/
eMASReferencialJs.GenerarComponenteFechaHora = function (dateTimePicker, format, defaultDateTime, name, isRequired) {
	var faDateOrTime = format === "TIME" ? "'fa fa-clock-o'" : "'fa fa-calendar'";
    dateTimePicker.addClass('input-group date');
    dateTimePicker.css('width', '100%');
    if (name !== undefined && isRequired !== undefined) {
        dateTimePicker.append('<input type="text" class="form-control" name="' + name + '" required />');
        dateTimePicker.append('<span class="input-group-addon"><div class="btnDateTimeEdit"><i class=' + faDateOrTime + '></i></div></span>');
        dateTimePicker.append('<div class="invalid-feedback">Campo requerido.</div>');
    }
    else {
        dateTimePicker.append('<input type="text" class="form-control" />');
        dateTimePicker.append('<span class="input-group-addon"><div class="btnDateTimeEdit"><i class=' + faDateOrTime + '></i></div></span>');
    }
    dateTimePicker.datetimepicker({
        format: format === "DATETIME" ? 'DD/MM/YYYY HH:mm' : format === "DATE" ? 'DD/MM/YYYY' : format === "TIME" ? 'HH:mm' : false,
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down"
        },
        defaultDate: defaultDateTime === null || defaultDateTime === "" || defaultDateTime === undefined ? false : defaultDateTime
    });
    return dateTimePicker;
};

/*Devuelve la fecha en formato yyyy-mm-dd para insertar*/
eMASReferencialJs.ObtenerFecha = function (dateTimePicker) {
    try {
        var date = dateTimePicker.data("DateTimePicker").date()._d;
        return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    }
    catch (error) {
        return "";
    }
};

eMASReferencialJs.VincularComponenteFechaHora = function (primerComponente, segundoComponente) {
    primerComponente.on("dp.change", function (e) {
        segundoComponente.data("DateTimePicker").minDate(e.date);
    });
    segundoComponente.on("dp.change", function (e) {
        primerComponente.data("DateTimePicker").maxDate(e.date);
    });
};

eMASReferencialJs.ConvertirFecha = function (fecha) {
    var fechaConvertida = '';
    if (fecha !== null) {
        var date = fecha.split("/");
        fechaConvertida = date[2] + "-" + date[1] + "-" + date[0];
    }
    return fechaConvertida;
};

eMASReferencialJs.ObtenerFechaFormatoYYYYMMDD = function (componente) {
    try {
        var fecha = componente.data("DateTimePicker").date()._d;
        return fecha.getFullYear() + "-" + (fecha.getMonth() + 1) + "-" + fecha.getDate();
    }
    catch (error) {
        return null;
    }
};

eMASReferencialJs.FormatoMes = function (valor, fila, posicion) {
	var texto;
    switch (valor) {
        case 1:
			texto = "Enero";
            break;
        case 2:
			texto = "Febrero";
            break;
        case 3:
			texto = "Marzo";
            break;
        case 4:
			texto = "Abril";
            break;
        case 5:
			texto = "Mayo";
            break;
        case 6:
			texto = "Junio";
            break;
        case 7:
			texto = "Julio";
            break;
        case 8:
			texto = "Agosto";
            break;
        case 9:
			texto = "Septiembre";
            break;
        case 10:
			texto = "Octubre";
            break;
        case 11:
			texto = "Noviembre";
            break;
        case 12:
			texto = "Diciembre";
            break;
	}
	return texto;
};

eMASReferencialJs.FormatoFecha = function (valor, fila, posicion) {
    return moment(valor).format('MM/DD/YYYY');
};

/////////////////////////////// TABLA ////////////////////////////////

/*Crea el componente de la tabla*/
eMASReferencialJs.GenerarComponenteTabla = function (table, uniqueId, columns, idToolbar, data, search) {
    if (idToolbar !== null) {
        table.bootstrapTable({
            uniqueId: uniqueId,
            columns: columns,
            toolbar: idToolbar,
            search: search
        });
    }
    else {
        table.bootstrapTable({
            uniqueId: uniqueId,
            columns: columns,
            search: search
        });
    }
    table.children('thead').addClass('theadTable');
    table.bootstrapTable('load', data === null ? [] : data);
};

/*Formato para las casillas de selección en las tablas*/
eMASReferencialJs.FormatoCasillaSeleccion = function (value, row, index) {
    if (value) {
        return "<input type='checkbox' checked disabled>";
    }
    else {
        return "<input type='checkbox' disabled>";
    }
};

/*Devuelve una fila seleccionada de una tabla*/
eMASReferencialJs.ObtenerSeleccion = function (table) {
    return $.map(table.bootstrapTable('getSelections'), function (row) {
        return row;
    })[0];
};

/*Devuelve varias filas seleccionadas de una tabla*/
eMASReferencialJs.ObtenerSelecciones = function (table) {
    return $.map(table.bootstrapTable('getSelections'), function (row) {
        return row;
    });
};

////////////////////////////// SELECTOR //////////////////////////////

/*Crea el componente del selector*/
eMASReferencialJs.GenerarComponenteSelector = function (select) {
    select.chosen({ width: '100%' });
    select.trigger("chosen:updated");
};

/*Inserta elementos al componente del selector y selecciona uno.*/
eMASReferencialJs.InsertarElementosComponenteSelector = function (select, items) {
    var value = select.val();
    select.empty().append($('<option>', {
        value: 0,
        text: "Seleccione..."
    }));
    $.each(items, function (i, item) {
        select.append($('<option>', {
            value: item.Value,
            text: item.Text
        }));
	});
	if (value !== null && items.findIndex(x => x.Value === value) < 0) {
		value = 0;
	}
    select.val(value !== null ? value : 0);
    select.trigger("chosen:updated");
};

/*Inserta un elemento al componente del selector y lo selecciona*/
eMASReferencialJs.InsertarElementoComponenteSelector = function (select, value, text) {
    select.empty().append($('<option>', {
        value: 0,
        text: "Seleccione..."
    }));
    select.append($('<option>', {
        value: value,
        text: text
    }));
    select.val(value !== null ? value : 0);
    select.trigger("chosen:updated");
};

/*Limpia el componente del selector*/
eMASReferencialJs.LimpiarComponenteSelector = function (select) {
    select.empty().append($('<option>', {
        value: 0,
        text: "Seleccione..."
    }));
    select.val(0);
    select.trigger("chosen:updated");
};

/////////////////////////// LLAMADA AJAX /////////////////////////////

eMASReferencialJs.Ajax = function (request, failFunction, typeMessage) {
    $.ajax(
        request
	).fail(function (response, textstatus, errorThrown) {
		var texto = '';
		if (response.status === 403 || response.status === 401) {
			eMASReferencialJs.ocultarProgress();
			texto = "<span>Su sesión ha caducado, para volver a iniciar presione </span><a href='" + eMASReferencialJs.serverPath + "'><b>Aquí</b></a>";
            eMASReferencialJs.mostrarMensajes("Sesión", eMASReferencialJs.tipoMensaje.Advertencia, [{ Description: texto }], []);
		}
		else {

			var mensaje = eMASReferencialJs.Error.ErrorGeneral + " Detalle los siguientes datos para salucionar el problema. </br>" + "Ruta: " + request.url;
			//+ "</br> Estado: " + textstatus + "</br> Error: " + errorThrown;
			if (response.status.toString() !== "") {
				mensaje = mensaje + "</br> StatusCode: " + response.status.toString();
			}
			if (response.statusText !== "") {
				mensaje = mensaje + "</br> StatusText: " + response.statusText;
			}
			if (response.responseText !== "") {
				mensaje = mensaje + "</br> ResponseText: " + response.responseText;
			}

            if (failFunction !== null)
                failFunction();
			if (typeMessage === 'alert')
				$('#div-alert').html("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" + mensaje + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>");
			else {				
				eMASReferencialJs.mostrarMensajes("Error", eMASReferencialJs.tipoMensaje.Error, [{ Description: mensaje }], [eMASReferencialJs.botonAceptar]);
			}                
        }
    });
};

// General Formularios Configuración

eMASReferencialJs.SetearEventosPanel = function () {
    $('.panel-collapse').on('show.bs.collapse', function () {
        $(this).siblings('.panel-heading').addClass('active');
    });

    $('.panel-collapse').on('hide.bs.collapse', function () {
        $(this).siblings('.panel-heading').removeClass('active');
    });
};

eMASReferencialJs.ObtenerAppConfig = function () {
    let _rutaBase = $("#hdnRutaBase").val();


    let _appConfig = {
        "RutaBase": _rutaBase
    }

    return _appConfig;
};

eMASReferencialJs.FormSetVisibilityConsult = function (visibility, tableName) {
    let _consultLs = document.querySelector(".consult-ls");

    if (_consultLs != undefined)
        _consultLs.style.display = visibility ? "" : "none";

    if (tableName == "" || tableName == undefined)
        return;

    let dataConsulta = $("#" + tableName).bootstrapTable('getOptions');

    if (!(dataConsulta == null && dataConsulta == undefined)) {
        if (dataConsulta.totalRows == 0 || dataConsulta.totalRows == undefined) {
            if (visibility) {
                if (_consultLs != undefined)
                    _consultLs.style.display = "none";
            }
        }
    }
};

eMASReferencialJs.FormSetVisibilityPanel = function (visibility) {
    let _panelFilter = document.querySelector(".panel-filter");
    
    if (_panelFilter != undefined)
        _panelFilter.style.display = visibility ? "" : "none";
};

eMASReferencialJs.htmlToElement = function(html) {
    var template = document.createElement('template');
    html = html.trim(); 
    template.innerHTML = html;
    return template.content.firstChild;
}

eMASReferencialJs.SetearMensajeDefaultAdvertencia = function (mensaje) {
    eMASReferencialJs.mostrarMensajes(eMASReferencialJs.Advertencia.Titulo
        , eMASReferencialJs.tipoMensaje.Advertencia
        , [{ Description: mensaje }]
        , [eMASReferencialJs.botonAceptar]);
};

eMASReferencialJs.SetearMensajeDefaultExito = function (mensaje) {
    eMASReferencialJs.mostrarMensajes(eMASReferencialJs.Exito.Titulo
        , eMASReferencialJs.tipoMensaje.Exito
        , [{ Description: mensaje }]
        , [eMASReferencialJs.botonAceptar]);
};

eMASReferencialJs.SetearPlantillaPagineo = function (metodoBusqueda, pagineoContainer, totalPaginas, paginaActual) {
    let plantilla = "";
    let listaNumeracion = "";
    let TotalPaginas = totalPaginas;
    let PaginaActual = paginaActual;
    let Pagineo = $("#" + pagineoContainer);
    let ArrNumeroPaginas = Array();

    let contador = 1;
    for (let i = PaginaActual; i <= TotalPaginas; i++) {
        ArrNumeroPaginas[0] = paginaActual;
        if (TotalPaginas != PaginaActual
            && ArrNumeroPaginas[contador - 1] != TotalPaginas) {
            ArrNumeroPaginas[contador] = i + 1;
        }
        contador++;
    }
    // Dejamos solo 5 páginas para navegar
    ArrNumeroPaginas = ArrNumeroPaginas.slice(0, 5);
    let primeraPagina = 1;
    let ultimaPagina = TotalPaginas;
    let avanzar = 1;
    if (TotalPaginas != PaginaActual) {
        avanzar = PaginaActual + 1;
    }
    let retroceder = 1;
    if (PaginaActual > 1) {
        retroceder = PaginaActual - 1;
    }

    plantilla += "<ul class=\"pagination justify-content-center\">";
    plantilla += "<li class=\"page-item\">";
    plantilla += "<a class=\"page-link\" href=\"#\" onclick=\"" + metodoBusqueda +"('" + primeraPagina + "')\">";
    plantilla += "<i class=\"fa fa-fast-backward\"></i>";
    plantilla += "</a></li>";
    plantilla += "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" onclick=\"" + metodoBusqueda + "('" + retroceder + "')\">";
    plantilla += "<i class=\"fa fa-backward\"></i></a></li>";

    for (let i = 0; i < ArrNumeroPaginas.length; i++) {
        listaNumeracion += "<li class=\"page-item\">"
        listaNumeracion += "<a class=\"page-link active\" onclick=\"" + metodoBusqueda + "('" + ArrNumeroPaginas[i] + "')\" href=\"#\">";
        listaNumeracion += (ArrNumeroPaginas[i] === PaginaActual ? "<strong>" + ArrNumeroPaginas[i] + "</strong>" : ArrNumeroPaginas[i]) + '</a>';
        listaNumeracion += "</li>"
    }

    plantilla += listaNumeracion + "<li class=\"page-item\"><a class=\"page-link\" href=\"#\" onclick=\"" + metodoBusqueda + "('" + avanzar + "')\">";
    plantilla += "<i class=\"fa fa-forward\"></i></a></li>";
    plantilla += "<li class=\"page-item\">";
    plantilla += "<a class=\"page-link\" href=\"#\" onclick=\"" + metodoBusqueda + "('" + ultimaPagina + "')\">";
    plantilla += "<i class=\"fa fa-fast-forward\"></i></a></li></ul>";

    Pagineo.append(plantilla);
}

eMASReferencialJs.EncontrarMensaje = function (mensaje) {
    return mensaje.codigo == this.codigo;
}

eMASReferencialJs.SetearEvtFormularioGenerico = function (fnRegresar, fnCancelar, fnGuardar, fnEliminar) {
    let _RegresarCtrl = document.querySelector(".regresar-edit");
    let _CancelarCtrl = document.querySelector(".cancelar-edit");
    let _GuardarCtrl = document.querySelector(".guardar-edit");
    let _EliminarCtrl = document.querySelector(".eliminar-edit");

    _RegresarCtrl.removeEventListener('click', fnRegresar);
    _RegresarCtrl.addEventListener('click', fnRegresar);

    _CancelarCtrl.removeEventListener('click', fnCancelar);
    _CancelarCtrl.addEventListener('click', fnCancelar);

    _GuardarCtrl.removeEventListener('click', fnGuardar);
    _GuardarCtrl.addEventListener('click', fnGuardar);

    _EliminarCtrl.removeEventListener('click', fnEliminar);
    _EliminarCtrl.addEventListener('click', fnEliminar);
};

eMASReferencialJs.InicializarPanelGenerico = function (nombrePanel, fnNuevo, fnLimpiar, fnConsultar) {
    let _panelFilter = document.querySelector("#" + nombrePanel + " .panel-body");
    let _consultLs = document.querySelector(".consult-ls");
    let _btnConsultar = document.querySelector(".consultar");
    let _btnLimpiar = document.querySelector(".limpiar");
    let _btnNuevo = document.querySelector(".nuevo");

    if (_panelFilter != undefined)
        eMASReferencialJs.SetearEventosPanel();

    if (_consultLs != undefined)
        _consultLs.style.display = "none";

    if (_btnConsultar != undefined) {
        _btnConsultar.addEventListener('click', fnConsultar);
    }
    if (_btnLimpiar != undefined) {
        _btnLimpiar.addEventListener('click', fnLimpiar);
    }
    if (_btnNuevo != undefined) {
        _btnNuevo.addEventListener('click', fnNuevo);
    }
    eMASReferencialJs.FormSetVisibilityConsult(false);
}

eMASReferencialJs.CargarCombosGenerico = function (data) {    
    data.forEach(function (_dataItem) {
        let dataBody = { key1: _dataItem.key, target: _dataItem.ctrl };
        eMASReferencialJs.FetchPost(_dataItem.ruta, dataBody, eMASReferencialJs.CargarCombosGenericoRespuesta);
    });
};

eMASReferencialJs.LimpiarControlesHtml = function (panelName) {
    let ctrlContenedor = document.querySelector(panelName);
    if (ctrlContenedor == null || ctrlContenedor == undefined)
        return;

    // Limpiar Inputs
    let inputs = ctrlContenedor.querySelectorAll("input");

    if (!(inputs == null || inputs == undefined)) {
        inputs.forEach(function (element) {
            element.value = "";
        });
    }
    let selects = ctrlContenedor.querySelectorAll("select");

    if (!(selects == null || selects == undefined)) {
        selects.forEach(function (element) {
            element.selectedIndex = -1;
        });
    }
};

eMASReferencialJs.CargarCombosGenericoRespuesta = function (data) {
    debugger;
    if (data == null || data == undefined) {
        console.log("Respuesta incorrecta del servidor CargarCombosGenerico (1)");
        return;
    }
    if (data.key == null || data.key == undefined || data.key == ""
        || data.target == null || data.target == undefined || data.target == "") {
        console.log("Respuesta incorrecta del servidor CargarCombosGenerico (2)");
        return;
    }
    if (!(data.datasource == null || data.datasource == undefined)) {
        let itemCtrlSelect = document.querySelector(`#${data.target}`);
        if (!(itemCtrlSelect == undefined || itemCtrlSelect == null)) {
            let options = "";
            data.datasource.forEach(function(item) {
                options += `<option value=${item.key}>${item.value}</option>\n`;
            });
            itemCtrlSelect.innerHTML = options;
            itemCtrlSelect.selectedIndex = -1;
        }
    }
};

eMASReferencialJs.FetchPost = function (ruta, dataBody, fnSuccessCallback) {
    let _appConfig = eMASReferencialJs.ObtenerAppConfig();
    let rutaBase = _appConfig.RutaBase;
    rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
    let url = rutaBase + ruta;

    fetch(url, {
        method: 'POST',
        headers: { "Content-type": "application/json;charset=UTF-8" },
        body: JSON.stringify(dataBody)
    }).then(res => res.json())
        .then(fnSuccessCallback)
        .catch(function (error) {
            console.log('Fetchpost Generic Error', error);
        });
};

eMASReferencialJs.ObtenerAnioSistema = function () {
    const date = new Date();
    return date.getFullYear();
}
