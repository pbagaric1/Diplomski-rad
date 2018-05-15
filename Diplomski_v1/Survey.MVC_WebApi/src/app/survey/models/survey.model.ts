﻿export class SurveyModel {

    public id : string;
    public userId: string;
    public organization: string;
    public name: string;
    //public instructions: string;
    public createdOn : string;
    public questions: string[];
    public visibility: boolean;
 //   public userName: string;

    constructor(id: string, userId: string, name: string, organization: string, createdOn: string, questions: string[],
                visibility: boolean) {

        this.id = id;
        this.userId = userId;
        this.name = name;
        this.organization = organization;
        //this.instructions = instructions;
        this.createdOn = createdOn;
        this.questions = questions;
        this.visibility = visibility;
       // this.userName = userName;
    }
}