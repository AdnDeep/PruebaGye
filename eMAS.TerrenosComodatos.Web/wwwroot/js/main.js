

$(function() {

	"use strict";

	[].slice.call( document.querySelectorAll( 'select.cs-select' ) ).forEach( function(el) {
		new SelectFx(el);
	} );

	jQuery('.selectpicker').selectpicker;


	$('#menuToggle').on('click', function(event) {
		$('body').toggleClass('open');
	});

	$('.search-trigger').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').addClass('open');
	});

	$('.search-close').on('click', function(event) {
		event.preventDefault();
		event.stopPropagation();
		$('.search-trigger').parent('.header-left').removeClass('open');
	});

	$('.amenu').click(function (event) {
		event.preventDefault();
		let _area = $(this).data("area");
		let _controlador = $(this).data("controlador");
		let _appConfig = eMASReferencialJs.ObtenerAppConfig();

		let rutaBase = _appConfig.RutaBase;
		rutaBase = rutaBase === "/" ? "/" : (rutaBase + "/");
		let url = rutaBase + _area + "/" + _controlador + "/Index";

		let title = this.title;

		var appInsights = function (a) {
			function b(a) { c[a] = function () { var b = arguments; c.queue.push(function () { c[a].apply(c, b) }) } } var c = { config: a }, d = document, e = window; setTimeout(function () { var b = d.createElement("script"); b.src = a.url || "https://az416426.vo.msecnd.net/scripts/a/ai.0.js", d.getElementsByTagName("script")[0].parentNode.appendChild(b) }); try { c.cookie = d.cookie } catch (a) { } c.queue = []; for (var f = ["Event", "Exception", "Metric", "PageView", "Trace", "Dependency"]; f.length;)b("track" + f.pop()); if (b("setAuthenticatedUserContext"), b("clearAuthenticatedUserContext"), b("startTrackEvent"), b("stopTrackEvent"), b("startTrackPage"), b("stopTrackPage"), b("flush"), !a.disableExceptionTracking) { f = "onerror", b("_" + f); var g = e[f]; e[f] = function (a, b, d, e, h) { var i = g && g(a, b, d, e, h); return !0 !== i && c["_" + f](a, b, d, e, h), i } } return c
		}({
			instrumentationKey: eMASReferencialJs.instrumentationKey
		});
		window.appInsights = appInsights, appInsights.trackPageView(title, url);
		
		eMASReferencialJs.Ajax({
			type: "POST",
			data: null,
			url: url,
			beforeSend: function (response) {
				eMASReferencialJs.mostrarProgress();
			},
			success: function (response) {
				//$('#tituloPagina').find('h3').html(title);
				$('#toolbarPagina').html("");
				$('#toolbarRegresar').empty();
				$("#pageContainer").html(response);
			}
		}, function () { eMASReferencialJs.ocultarProgress(); });

		
	});


});