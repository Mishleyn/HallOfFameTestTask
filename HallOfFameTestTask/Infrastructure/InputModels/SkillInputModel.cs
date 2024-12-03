using HallOfFameTestTask.Application.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HallOfFameTestTask.Infrastructure.InputModels;

public class SkillInputModel
{
    public string Name { get; set; }

    [JsonConverter(typeof(SkillLevelConverter))]
    public byte Level { get; set; }
}
