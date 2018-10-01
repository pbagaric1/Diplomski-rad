using System;

namespace Survey.DAL.Models
{
  public class SavedPoll
  {
    public Guid Id { get; set; }
    public string AspNetUserId { get; set; }
    public Guid PollId { get; set; }
    public DateTime DateAdded { get; set; }

    //public virtual Poll Poll { get; set; }
  }
}