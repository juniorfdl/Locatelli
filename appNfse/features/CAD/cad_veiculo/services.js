

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
        var CrudCad_VeiculoService = (function (_super) {
            __extends(CrudCad_VeiculoService, _super);

            function CrudCad_VeiculoService($q, api, $rootScope) {
                _super.apply(this, arguments);

                this.GetProprietario = GetProprietario;
            }

            function GetProprietario(DOCUMENTO) {
                return this.api.allLook(null, 'cad_pessoa/documento/' + DOCUMENTO);
            }

            Object.defineProperty(CrudCad_VeiculoService.prototype, "baseEntity", {
                /// @override
                get: function () {
                    return 'CAD_Veiculo';
                },
                enumerable: true,
                configurable: true
            });            
   
            return CrudCad_VeiculoService;
        })(Services.CrudBaseService);
        Services.CrudCad_VeiculoService = CrudCad_VeiculoService;
        App.modules.Services
            .service('CrudCad_VeiculoService', CrudCad_VeiculoService);
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=services.js.map