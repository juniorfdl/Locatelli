
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

                this.GetProprietarioPlaca = function (event) {
                    if (event.keyCode == 13) {
                        if (_this.currentRecord != null && _this.currentRecord.DOCS != null) {
                            _this.crudSvc.GetProprietarioPlaca(_this.currentRecord.DOCS).then(function (dados) {
                                _this.currentRecord.DOCS = null;
                                if (dados != null) {
                                    _this.currentRecord.NOME_PESSOA = dados.NOME_PESSOA;
                                    _this.currentRecord.COD_CADPESSOA = dados.COD_CADPESSOA;
                                    _this.currentRecord.COD_CADVEICULO = dados.COD_CADVEICULO;
                                    _this.currentRecord.DOCUMENTO_PESSOA = dados.DOCUMENTO_PESSOA;
                                    _this.currentRecord.NOME_PESSOA_AP = dados.NOME_PESSOA_AP
                                    _this.currentRecord.DOCUMENTO_PESSOA_AP = dados.DOCUMENTO_PESSOA_AP;

                                    if (dados.PLACA != null)
                                        _this.currentRecord.PLACA = dados.PLACA;

                                    if (dados.TORRE > 0)
                                        _this.currentRecord.TORRE = dados.TORRE;

                                    _this.currentRecord.GARAGEM = dados.GARAGEM;

                                    if (dados.COD_CADAPARTAMENTO > 0)
                                        _this.currentRecord.COD_CADAPARTAMENTO = dados.COD_CADAPARTAMENTO;
                                }
                                else {
                                    _this.currentRecord.COD_CADPESSOA = null;
                                    _this.currentRecord.COD_CADVEICULO = null;
                                }
                                _this.$rootScope.Cadastro = true;
                            });
                        } else {
                            _this.$rootScope.Cadastro = true;
                        }
                    }
                    else {
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
                this.currentRecord.PLACA = this.currentRecord.PLACA.toUpperCase().replace('-', '');
            };

            return CrudMov_EntradaCtrl;
        })(Controllers.CrudBaseEditCtrl);
        Controllers.CrudMov_EntradaCtrl = CrudMov_EntradaCtrl;

        App.modules.Controllers.controller('CrudMov_EntradaCtrl', CrudMov_EntradaCtrl);

    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=ctrl.js.map