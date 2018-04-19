"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var auth_service_1 = require("./../auth/auth.service");
var core_1 = require("@angular/core");
var TokenInterceptor = /** @class */ (function () {
    function TokenInterceptor(authService) {
        this.authService = authService;
    }
    TokenInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        // console.log("pocelo");
        var token = this.authService.getToken();
        request = request.clone({
            setHeaders: {
                'Authorization': "Bearer " + token
            }
        });
        return next.handle(request)
            .do(function (succ) {
            console.log(succ);
        }, function (err) {
            console.log(err.status);
            if (err.status === 401 || (err.status === 400 && err.statusText === 'invalid_grant')) {
                _this.authService.logOut();
            }
            // if(err.)
        });
    };
    TokenInterceptor = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [auth_service_1.AuthService])
    ], TokenInterceptor);
    return TokenInterceptor;
}());
exports.TokenInterceptor = TokenInterceptor;
//# sourceMappingURL=token.interceptor.js.map