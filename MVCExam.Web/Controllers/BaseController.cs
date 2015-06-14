using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Web.Controllers
{
    using Data.Contracts;
    using Data.UnitOfWork;

    public abstract class BaseController : Controller
    {

        protected ExamData data;
        public BaseController(IExamData data)
        {
            this.data = data as ExamData;
        }
        public BaseController()
            : this(new ExamData())
        {

        }

	}
}