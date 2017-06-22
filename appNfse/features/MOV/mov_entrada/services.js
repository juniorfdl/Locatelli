

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
        var CrudMov_EntradaService = (function (_super) {
            __extends(CrudMov_EntradaService, _super);

            function CrudMov_EntradaService($q, api, $rootScope) {
                _super.apply(this, arguments);

                this.GetProprietarioPlaca = GetProprietarioPlaca;
            }              

            function GetProprietarioPlaca(PLACA) {
                return this.api.allLook(null, 'cad_pessoa/placa/' + PLACA);
            }

            Object.defineProperty(CrudMov_EntradaService.prototype, "baseEntity", {
                /// @override
                get: function () {
                    return 'Mov_Entrada';
                },
                enumerable: true,
                configurable: true
            });            
   
            return CrudMov_EntradaService;
        })(Services.CrudBaseService);
        Services.CrudMov_EntradaService = CrudMov_EntradaService;
        App.modules.Services
            .service('CrudMov_EntradaService', CrudMov_EntradaService);
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=services.js.map