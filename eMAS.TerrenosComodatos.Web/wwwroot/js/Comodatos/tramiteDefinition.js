class Tramite {
    constructor(_arrCtrls) {
        this.arrCtrls = _arrCtrls;
        this.MAX_SOLAR_VALUE = 99999999999;
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
    ValidateDataAndGetObjWithValues( objRespuesta) {
        let objCtrlWithValues = this.GetDataWithValues();
        
        if (objCtrlWithValues.beneficiarioEdit == undefined || objCtrlWithValues.beneficiarioEdit == null) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Seleccionar el Beneficiario es Obligatorio  y no puede ser 0.";
            return;
        }
        if (objCtrlWithValues.sectorEdit == undefined || objCtrlWithValues.sectorEdit == null
            || objCtrlWithValues.sectorEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar el sector es Obligatorio y no puede ser 0.";
            return;
        }
        if (objCtrlWithValues.manzanaEdit == undefined || objCtrlWithValues.manzanaEdit == null
            || objCtrlWithValues.manzanaEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar la manzana es Obligatorio  y no puede ser 0.";
            return;
        }
        if (objCtrlWithValues.loteEdit == undefined || objCtrlWithValues.loteEdit == null
            || objCtrlWithValues.loteEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar el Lote es Obligatorio.";
            return;
        }
        //if (objCtrlWithValues.divisionEdit == undefined || objCtrlWithValues.divisionEdit == null
        //    || objCtrlWithValues.divisionEdit == 0) {
        //    objRespuesta.isValid = false;
        //    objRespuesta.mensaje = "Indicar la divisi&oacute;n es Obligatorio.";
        //    return;solarEdit
        //}
        if (!(objCtrlWithValues.solarEdit == undefined || objCtrlWithValues.loteEdit == null)) {
            let _solarTmp = parseFloat(objCtrlWithValues.solarEdit);

            if (_solarTmp > this.MAX_SOLAR_VALUE) {
                objRespuesta.isValid = false;
                objRespuesta.mensaje = `El solar no puede ser mayor a ${this.MAX_SOLAR_VALUE.toString()}`;
                return;
            }
        }
        if (objCtrlWithValues.tipoContratoEdit == undefined || objCtrlWithValues.tipoContratoEdit == null
            || objCtrlWithValues.tipoContratoEdit == 0) {
            objRespuesta.isValid = false;
            objRespuesta.mensaje = "Indicar el Tipo de Contrato es Obligatorio.";
            return;
        }
        if (objCtrlWithValues.IdTramite > 0) {
            if (objCtrlWithValues.estadoEdit == undefined || objCtrlWithValues.estadoEdit == null
                || objCtrlWithValues.estadoEdit == 0) {
                objRespuesta.isValid = false;
                objRespuesta.mensaje = "Indicar el Estado es Obligatorio.";
                return;
            }
        }

        let _fechaInspeccion = eMASReferencialJs.FormatearFecha(objCtrlWithValues.fechaInspeccionEdit);
        let _fechaAprobacion = eMASReferencialJs.FormatearFecha(objCtrlWithValues.fechaAprobacionEdit);
        let _fechaEscritura = eMASReferencialJs.FormatearFecha(objCtrlWithValues.fechaEscrituraEdit);
        
        let dataJsonClServer = {};
        dataJsonClServer["idtramite"] = objCtrlWithValues.IdTramite;
        dataJsonClServer["idbeneficiario"] = objCtrlWithValues.beneficiarioEdit;
        dataJsonClServer["idsector"] = objCtrlWithValues.sectorEdit;
        dataJsonClServer["manzana"] = objCtrlWithValues.manzanaEdit;
        dataJsonClServer["lote"] = objCtrlWithValues.loteEdit;
        dataJsonClServer["division"] = objCtrlWithValues.divisionEdit;
        dataJsonClServer["phv"] = objCtrlWithValues.phvEdit;
        dataJsonClServer["phh"] = objCtrlWithValues.phhEdit;
        dataJsonClServer["numero"] = objCtrlWithValues.numeroEdit;
        dataJsonClServer["oficioag"] = objCtrlWithValues.oficioAgEdit;
        dataJsonClServer["oficiodase"] = objCtrlWithValues.oficioDaseEdit;
        dataJsonClServer["strareasolar"] = objCtrlWithValues.solarEdit;
        dataJsonClServer["fechainsregprop"] = _fechaInspeccion;
        dataJsonClServer["aprobacionconcejomun"] = objCtrlWithValues.oficioAprobacionEdit;
        dataJsonClServer["fechaaprobconcejomun"] = _fechaAprobacion;
        dataJsonClServer["idtipocontrato"] = objCtrlWithValues.tipoContratoEdit;
        dataJsonClServer["aniosplazo"] = objCtrlWithValues.aniosPlazoEdit;
        dataJsonClServer["fechaescritura"] = _fechaEscritura;
        dataJsonClServer["oficiorevocatoriamod"] = objCtrlWithValues.oficioRevocatoriaEdit;
        dataJsonClServer["idestado"] = objCtrlWithValues.estadoEdit;

        return dataJsonClServer;
    }
}