using System;
using Ardalis.GuardClauses;
using ChatMessage.Core.ProjectAggregate.Enums;
using ChatMessage.SharedKernel;

namespace ChatMessage.Core.ProjectAggregate;


public class Message : EntityBase
{
  public string OwnerId { get; set; } = string.Empty;
  public bool HasRepaly { get; set; }
  public bool IsRepaly { get; set; } 
  public string ReplayMessageId { get; set; } = string.Empty;
  public bool? IsDeleted { get; set; }
  public string Body { get; set; } = string.Empty;
  public FileTypeEnum FileType { get; set; }
  public int ContantSize { get; set; }
  public byte[] Contant { get; set; } = new byte[9000];

  private  Message(string ownerId, bool hasRepaly, bool isRepaly,
    string replayMessageId, bool? isDeleted, string body,
    FileTypeEnum fileType,
    int contantSize, byte[] contant)
  {


    OwnerId = Guard.Against.Null(ownerId, nameof(ownerId));
    HasRepaly = hasRepaly;
    IsRepaly = isRepaly;
    ReplayMessageId = replayMessageId;
    IsDeleted = isDeleted;
    Body = Guard.Against.Null(body, nameof(body));
    FileType = fileType;
    ContantSize = contantSize;
    Contant = contant;
  }


  public static Message CreateMessage(string ownerId, bool hasRepaly, bool isRepaly,
    string replayMessageId, bool? isDeleted, string body,
    FileTypeEnum fileType,
    int contantSize, byte[] contant)
  {
    return new Message(ownerId, hasRepaly, isRepaly,
    replayMessageId, isDeleted, body,
    fileType,
    contantSize, contant);
  }


}



