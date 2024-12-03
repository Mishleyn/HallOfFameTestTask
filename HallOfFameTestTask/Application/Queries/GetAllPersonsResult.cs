﻿using HallOfFameTestTask.Infrastructure.OutputModels;

namespace HallOfFameTestTask.Application.Queries;

public class GetAllPersonsResult
{
    public List<PersonOutputModel> Persons { get; set; } = new();
}
