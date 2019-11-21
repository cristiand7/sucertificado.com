using ProyectoJaverianaDisYEvDAL.DAL;
using ProyectoJaverianaDisYEvEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoJaverianaDisYEvBL.BL
{
   public  class ResponseBL
    {
        public bool insertQuestionResponses(ResponseEntity questionResponse)
        {
            ResponseDAL questionResponseDAL = new ResponseDAL();
            return questionResponseDAL.insertQuestionResponse(questionResponse);

        }
        public List<ResponseEntity> GetResponsesFromQuestion(QuestionEntity questionResponse)
        {
            ResponseDAL questionResponseDAL = new ResponseDAL();
            return questionResponseDAL.GetResponsesFromQuestion(questionResponse);

        }

        public ResponseEntity GetCorrectResponseFromQuestion(QuestionEntity questionResponse)
        {
            ResponseDAL questionResponseDAL = new ResponseDAL();
            return questionResponseDAL.GetCorrectResponseFromQuestion(questionResponse);

        }

        public List<ResponseEntity> GetResponseFromQuestionID(int  QuestionId)
        {
            ResponseDAL questionResponseDAL = new ResponseDAL();
            return questionResponseDAL.GetResponseFromQuestionID(QuestionId);

        }

    }
}
