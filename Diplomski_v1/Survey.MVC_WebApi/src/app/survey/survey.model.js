"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Survey = (function () {
    function Survey(userId, pollTypeId, name, location, questions) {
        this.userId = userId;
        this.pollTypeId = pollTypeId;
        this.name = name;
        this.location = location;
        this.questions = questions;
    }
    return Survey;
}());
exports.Survey = Survey;
//# sourceMappingURL=survey.model.js.map