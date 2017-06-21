
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
        var CrudMov_EntradaCtrl = (function (_super) {

            __extends(CrudMov_EntradaCtrl, _super);
            function CrudMov_EntradaCtrl($rootScope, api, CrudMov_EntradaService, lista, $q, $scope, $filter) {
                var _this = this;
                _super.call(this);
                              
                this.$rootScope = $rootScope;
                this.api = api;
                this.crudSvc = CrudMov_EntradaService;
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

            CrudMov_EntradaCtrl.prototype.crud = function () {
                return "Mov_Entrada";
            };

            CrudMov_EntradaCtrl.prototype.prepararParaSalvar = function () {
                debugger;
                this.currentRecord.PLACA = this.currentRecord.PLACA.toUpperCase().replace('-','');
            };

            return CrudMov_EntradaCtrl;
        })(Controllers.CrudBaseEditCtrl);
        Controllers.CrudMov_EntradaCtrl = CrudMov_EntradaCtrl;     

        App.modules.Controllers.controller('CrudMov_EntradaCtrl', CrudMov_EntradaCtrl);

    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=ctrl.js.map