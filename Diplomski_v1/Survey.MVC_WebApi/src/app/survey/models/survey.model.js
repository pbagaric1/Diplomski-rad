"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SurveyModel = /** @class */ (function () {
    function SurveyModel(id, userId, name, organization, createdOn, questions) {
        this.id = id;
        this.userId = userId;
        this.name = name;
        this.organization = organization;
        //this.instructions = instructions;
        this.createdOn = createdOn;
        this.questions = questions;
    }
    return SurveyModel;
}());
exports.SurveyModel = SurveyModel;
//# sourceMappingURL=survey.model.js.map