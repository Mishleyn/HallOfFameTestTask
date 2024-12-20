﻿using HallOfFameTestTask.Infrastructure.InputModels;

namespace HallOfFameTestTask.Infrastructure.OutputModels;

/// <summary>
/// Выходная модель данных человека.
/// </summary>
public class PersonOutputModel
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Отображаемое имя.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Список входных моделей навыков.
    /// </summary>
    public List<SkillInputModel> Skills { get; set; }
}
