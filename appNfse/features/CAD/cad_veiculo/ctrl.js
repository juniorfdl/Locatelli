
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        'use strict';
        var CrudCad_VeiculoCtrl = (function (_super) {

            __extends(CrudCad_VeiculoCtrl, _super);
            function CrudCad_VeiculoCtrl($rootScope, api, CrudCad_VeiculoService, lista, $q, $scope, $filter) {
                var _this = this;
                _super.call(this);
                              
                this.$rootScope = $rootScope;
                this.api = api;
                this.crudSvc = CrudCad_VeiculoService;
                this.lista = lista;

                this.GetProprietario = function () {
                    if (_this.currentRecord.DOCUMENTO_PESSOA != null && _this.currentRecord.DOCUMENTO_PESSOA.length > 8) {
                        _this.crudSvc.GetProprietario(_this.currentRecord.DOCUMENTO_PESSOA).then(function (dados) {
                            if (dados != null) {
                                _this.currentRecord.NOME_PESSOA = dados.NOME;
                                _this.currentRecord.COD_CADPESSOA = dados.id;
                            } else {
                                _this.currentRecord.NOME_PESSOA = null;
                                _this.currentRecord.COD_CADPESSOA = null;
                            }
                        });
                    } else {
                        _this.currentRecord.NOME_PESSOA = null;
                        _this.currentRecord.COD_CADPESSOA = null;
                    }
                }
            }

            CrudCad_VeiculoCtrl.prototype.crud = function () {
                return "Cad_Veiculo";
            };

            CrudCad_VeiculoCtrl.prototype.prepararParaSalvar = function () {
                debugger;
                this.currentRecord.PLACA = this.currentRecord.PLACA.toUpperCase().replace('-','');
            };

            return CrudCad_VeiculoCtrl;
        })(Controllers.CrudBaseEditCtrl);
        Controllers.CrudCad_VeiculoCtrl = CrudCad_VeiculoCtrl;     

        App.modules.Controllers.controller('CrudCad_VeiculoCtrl', CrudCad_VeiculoCtrl);

    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=ctrl.js.map