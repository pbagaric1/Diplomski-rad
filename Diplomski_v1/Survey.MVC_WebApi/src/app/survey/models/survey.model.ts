export class Survey {

    public userId: string;
    public organization: string;
    public name: string;
    //public instructions: string;
    public createdOn : string;
    public questions: string[];

    constructor(userId: string, name: string, organization: string, createdOn: string, questions: string[]) {

        this.userId = userId;
        this.name = name;
        this.organization = organization;
        //this.instructions = instructions;
        this.createdOn = createdOn;
        this.questions = questions;
    }
}