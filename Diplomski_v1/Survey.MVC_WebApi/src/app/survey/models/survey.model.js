"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Survey = (function () {
    function Survey(userId, name, organization, createdOn, questions) {
        this.userId = userId;
        this.name = name;
        this.organization = organization;
        //this.instructions = instructions;
        this.createdOn = createdOn;
        this.questions = questions;
    }
    return Survey;
}());
exports.Survey = Survey;
//# sourceMappingURL=survey.model.js.map