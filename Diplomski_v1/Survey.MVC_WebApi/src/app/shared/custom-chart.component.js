"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var ngx_charts_1 = require("@swimlane/ngx-charts");
var d3 = require("d3");
var CustomChartComponent = /** @class */ (function (_super) {
    __extends(CustomChartComponent, _super);
    function CustomChartComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.colorScheme = 'cool';
        return _this;
    }
    CustomChartComponent.prototype.ngOnChanges = function () {
        this.update();
    };
    CustomChartComponent.prototype.update = function () {
        _super.prototype.update.call(this);
        this.dims = {
            width: this.width,
            height: this.height
        };
        this.xScale = this.getXScale();
        this.yScale = this.getYScale();
        this.setColors();
    };
    CustomChartComponent.prototype.getXScale = function () {
        var spacing = 0.2;
        this.xDomain = this.getXDomain();
        return d3.scaleBand()
            .rangeRound([0, this.dims.width])
            .paddingInner(spacing)
            .domain(this.xDomain);
    };
    CustomChartComponent.prototype.getYScale = function () {
        this.yDomain = this.getYDomain();
        return d3.scaleLinear()
            .range([this.dims.height, 0])
            .domain(this.yDomain);
    };
    CustomChartComponent.prototype.getXDomain = function () {
        return this.results.map(function (d) { return d.name; });
    };
    CustomChartComponent.prototype.getYDomain = function () {
        var values = this.results.map(function (d) { return d.value; });
        var min = Math.min.apply(Math, [0].concat(values));
        var max = Math.max.apply(Math, values);
        return [min, max];
    };
    CustomChartComponent.prototype.setColors = function () {
        this.colors = new ngx_charts_1.ColorHelper(this.colorScheme, 'ordinal', this.xDomain);
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], CustomChartComponent.prototype, "view", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object)
    ], CustomChartComponent.prototype, "results", void 0);
    CustomChartComponent = __decorate([
        core_1.Component({
            selector: 'custom-chart',
            templateUrl: './custom-chart.component.html'
        })
    ], CustomChartComponent);
    return CustomChartComponent;
}(ngx_charts_1.BaseChartComponent));
exports.CustomChartComponent = CustomChartComponent;
//# sourceMappingURL=custom-chart.component.js.map