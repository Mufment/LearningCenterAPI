namespace LearningCenterAPI.Learning.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}