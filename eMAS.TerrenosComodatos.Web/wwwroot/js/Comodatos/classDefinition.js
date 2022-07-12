class Tramite {
    constructor(_arrCtrls) {
        this.arrCtrls = _arrCtrls;
    };
    GetDataWithValues() {
        let ctrlValues = {};
        this.arrCtrls.forEach(function (element) {
            let _eleCtrl = document.getElementById(element);
            if (_eleCtrl != undefined)
                ctrlValues[element] = _eleCtrl.value;
            else
                ctrlValues[element] = undefined;
        });
        return ctrlValues;
    };
    ValidateDataAndGetObjWithValues(dataJsonClServer, objRespuesta) {
        let objCtrlWithValues = this.GetDataWithValues();
        /*
        
        public short idestado { get; set; }
        public string estado { get; set; }

        public DateTime? fechaescritura { get; set; }

        public string  { get; set; }
        public DateTime? fechainsrevocatoria { get; set; }
        public string observacionjuridico { get; set; }
        public string baseorigen { get; set; }

         */
        if (objCtrlWithValues.beneficiarioEdit == undefined || objCtrlWithValues.beneficiarioEdit == null) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Seleccionar el Beneficiario es Obligatorio.";
            return;
        }
        if (objCtrlWithValues.sectorEdit == undefined || objCtrlWithValues.sectorEdit == null
            || objCtrlWithValues.sectorEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar el sector es Obligatorio.";
            return;
        }
        if (objCtrlWithValues.manzanaEdit == undefined || objCtrlWithValues.manzanaEdit == null
            || objCtrlWithValues.manzanaEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar la manzana es Obligatorio.";
            return;
        }
        if (objCtrlWithValues.loteEdit == undefined || objCtrlWithValues.loteEdit == null
            || objCtrlWithValues.loteEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar la manzana es Obligatorio.";
            return;
        }
        if (objCtrlWithValues.divisionEdit == undefined || objCtrlWithValues.divisionEdit == null
            || objCtrlWithValues.divisionEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar la manzana es Obligatorio.";
            return;
        }

        let _fechaInspeccion = eMASReferencialJs.FormatearFecha(objCtrlWithValues.fechaInspeccionEdit);
        let _fechaEscritura = eMASReferencialJs.FormatearFecha(objCtrlWithValues.fechaEscrituraEdit);

        dataJsonClServer = {
            idtramite: objCtrlWithValues.IdTramite,
            idbeneficiario: objCtrlWithValues.beneficiarioEdit,
            idsector: objCtrlWithValues.sectorEdit,
            manzana: objCtrlWithValues.manzanaEdit,
            lote: objCtrlWithValues.loteEdit,
            division: objCtrlWithValues.divisionEdit,
            phv: objCtrlWithValues.phvEdit,
            phh: objCtrlWithValues.phhEdit,
            numero: objCtrlWithValues.numeroEdit,
            oficioag: objCtrlWithValues.oficioAgEdit,
            oficiodase: objCtrlWithValues.oficioDaseEdit,
            areasolar: objCtrlWithValues.solarEdit,
            fechainsregprop: _fechaInspeccion,
            aprobacionconcejomun: objCtrlWithValues.oficioAprobacionEdit,
            fechaaprobconcejomun: objCtrlWithValues.fechaAprobacionEdit,
            idtipocontrato: objCtrlWithValues.tipoContratoEdit,
            aniosplazo: objCtrlWithValues.aniosPlazoEdit,
            fechaescritura: _fechaEscritura,
            oficiorevocatoriamod: objCtrlWithValues.oficioRevocatoriaEdit
        };
    }
}