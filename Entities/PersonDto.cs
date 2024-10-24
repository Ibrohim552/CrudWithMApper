
public readonly record struct PersonReadInfo
(
    int Id,
    string Name,
    string SurName
);

public readonly record struct PersonCreateInfo
(
   string Name,
   string SurName,
   int Age,
   decimal Salary
);
public readonly record struct PersonUpdateInfo
(
   int Id,
   string Name,
   string SurName,
   int Age,
   decimal Salary
);