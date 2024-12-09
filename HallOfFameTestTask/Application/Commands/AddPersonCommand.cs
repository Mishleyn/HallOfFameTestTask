﻿using HallOfFameTestTask.Infrastructure.InputModels;
using MediatR;

namespace HallOfFameTestTask.Application.Commands;

public class AddPersonCommand : IRequest<long>
{
    public string Name { get; set; }

    public string DisplayName { get; set; }

    public List<SkillInputModel> Skills { get; set; }
}
