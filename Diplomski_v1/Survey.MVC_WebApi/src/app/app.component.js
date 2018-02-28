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
var forms_1 = require("@angular/forms");
var AppComponent = (function () {
    function AppComponent(_fb) {
        this._fb = _fb;
    }
    AppComponent.prototype.ngOnInit = function () {
        this.name = new forms_1.FormControl('', [forms_1.Validators.required]);
        this.sortItem = this._fb.array([this.initSort()]);
        this.form = this._fb.group({
            name: this.name,
            sortItem: this.sortItem
        });
    };
    AppComponent.prototype.initSort = function () {
        return this._fb.group({
            locationName: ['', [forms_1.Validators.required]],
            locationItems: this._fb.array([
                this.initSortItems()
            ])
        });
    };
    AppComponent.prototype.initSortItems = function () {
        return this._fb.group({
            itemName: ['', [forms_1.Validators.required]],
            itemPicture: ['', []],
        });
    };
    AppComponent.prototype.addSort = function () {
        this.sortItem.push(this.initSort());
    };
    AppComponent.prototype.addSortLocationItem = function (i, t) {
        var control = this.sortItem.at(i).get('locationItems');
        control.push(this.initSortItems());
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'app-root',
        templateUrl: './app.component.html'
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map