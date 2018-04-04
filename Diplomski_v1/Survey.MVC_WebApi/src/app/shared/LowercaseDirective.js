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
var core_1 = require("@angular/core");
var LowercaseDirective = (function () {
    function LowercaseDirective() {
        this.ngModelChange = new core_1.EventEmitter();
    }
    LowercaseDirective.prototype.onInputChange = function ($event) {
        this.value = $event.target.value.toLowerCase();
        this.ngModelChange.emit(this.value);
    };
    return LowercaseDirective;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], LowercaseDirective.prototype, "ngModelChange", void 0);
__decorate([
    core_1.HostListener('input', ['$event']),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", [Object]),
    __metadata("design:returntype", void 0)
], LowercaseDirective.prototype, "onInputChange", null);
LowercaseDirective = __decorate([
    core_1.Directive({
        selector: '[ngModel][lowercase]'
    })
], LowercaseDirective);
exports.LowercaseDirective = LowercaseDirective;
//# sourceMappingURL=LowercaseDirective.js.map