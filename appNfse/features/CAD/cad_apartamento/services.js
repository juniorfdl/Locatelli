var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};

var App;
(function (App) {
    var Services;
    (function (Services) {
        "use strict";
        var CrudCad_ApartamentoService = (function (_super) {
            __extends(CrudCad_ApartamentoService, _super);

            function CrudCad_ApartamentoService($q, api, $rootScope) {
                _super.apply(this, arguments);

                this.TorreLook = TorreLook;
                this.GetProprietario = GetProprietario;
            }

            function TorreLook() {
                var params = { Empresa: '', campoOrdenacao: 'id', direcaoAsc: true };
                return this.api.allLook(params, 'CAD_TORRE');
            };

            function GetProprietario(DOCUMENTO) {                
                return this.api.allLook(null, 'cad_pessoa/documento/' + DOCUMENTO);
            }

            Object.defineProperty(CrudCad_ApartamentoService.prototype, "baseEntity", {
                /// @override
                get: function () {
                    return 'CAD_Apartamento';
                },
                enumerable: true,
                configurable: true
            });            
   
            return CrudCad_ApartamentoService;
        })(Services.CrudBaseService);
        Services.CrudCad_ApartamentoService = CrudCad_ApartamentoService;
        App.modules.Services
            .service('CrudCad_ApartamentoService', CrudCad_ApartamentoService);
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=services.js.map