using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services
{
    public class TasksService : ITasksService
    {
        private readonly TasksRepository _tasksRepository;

        public TasksService(TasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public Tasks Get(long id)
        {
            try
            {
                var _task = _tasksRepository.Get(x => x.Id == id).FirstOrDefault();

                if (_task == null)
                {
                    return null;
                }

                return _task;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetAll()
        {
            try
            {
                var tasks = _tasksRepository.GetAll();

                return tasks;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Tasks Create(string name, string description)
        {
            try
            {
                Tasks task = new Tasks(name, description);
                _tasksRepository.Add(task);
                _tasksRepository.SaveChanges();
                return task;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /**
         * 
         * Poderia ter feito uma exclusão lógica aqui ao invés de apagar o registro do banco de dados, mas optei por fazer desta forma nesta ocasião.
         * 
         */
        public void Delete(long id)
        {
            try
            {
                var _task = this.Get(id);

                if (_task != null)
                {
                    _tasksRepository.Delete(_task);
                    _tasksRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Tasks? Update(long id, string name, string description, bool isComplete)
        {
            try
            {
                var _task = this.Get(id);

                if (_task == null)
                {
                    return null;
                }

                _task.UpdateTaskValues(name, description, isComplete);
                _tasksRepository.Update(_task);
                _tasksRepository.SaveChanges();

                return _task;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Tasks? UpdateIsComplete(long id, bool isComplete)
        {
            try
            {
                var _task = this.Get(id);

                if (_task == null)
                {
                    return null;
                }

                _task.SetIsComplete(isComplete);
                _tasksRepository.Update(_task);
                _tasksRepository.SaveChanges();

                return _task;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
