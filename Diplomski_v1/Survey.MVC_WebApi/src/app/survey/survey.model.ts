export class Survey {

    public userId: string;
    public pollTypeId: string;
    public name: string;
    public location: string;
    public questions: string[];

    constructor(userId: string, pollTypeId: string, name: string, location: string, questions: string[]) {

        this.userId = userId;
        this.pollTypeId = pollTypeId;
        this.name = name;
        this.location = location;
        this.questions = questions;
    }
}