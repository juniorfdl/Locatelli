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
        var CrudCad_ApartamentoCtrl = (function (_super) {

            __extends(CrudCad_ApartamentoCtrl, _super);
            function CrudCad_ApartamentoCtrl($rootScope, api, CrudCad_ApartamentoService, lista, $q, $scope, $filter) {
                var _this = this;
                _super.call(this);
                              
                this.$rootScope = $rootScope;
                this.api = api;
                this.crudSvc = CrudCad_ApartamentoService;
                this.lista = lista;

                TorreLook();

                function TorreLook() {
                    _this.crudSvc.TorreLook().then(function (lista) {
                        _this.TorreLook = lista;
                    });
                }

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

            CrudCad_ApartamentoCtrl.prototype.crud = function () {
                return "Cad_Apartamento";
            };

            CrudCad_ApartamentoCtrl.prototype.prepararParaSalvar = function () {               
            };

            CrudCad_ApartamentoCtrl.prototype.execAposNovo = function () {
                this.currentRecord.ATIVO = "S";
            };

            return CrudCad_ApartamentoCtrl;
        })(Controllers.CrudBaseEditCtrl);
        Controllers.CrudCad_ApartamentoCtrl = CrudCad_ApartamentoCtrl;     

        App.modules.Controllers.controller('CrudCad_ApartamentoCtrl', CrudCad_ApartamentoCtrl);

    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=ctrl.js.map