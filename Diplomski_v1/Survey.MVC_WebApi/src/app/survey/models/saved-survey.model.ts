export class SavedSurvey {

    public Id : string;
    public AspNetUserId: string;
    public PollJson: string;
    public DateAdded: string;


    constructor(id: string, aspNetUserId: string, pollJson: string, dateAdded: string) {

        this.Id = id;
        this.AspNetUserId = aspNetUserId;
        this.PollJson = pollJson;
        this.DateAdded = dateAdded;
    }
}