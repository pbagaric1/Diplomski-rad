import { Answer } from "../answer/answer.model";

export class Question {

    public name: string;
    public answers: Answer[];

    constructor(name: string, answers: Answer[]) {

        this.name = name;
        this.answers = answers;
    }
}