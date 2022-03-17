using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Test_Task.Controllers
{
    [ApiController]
    [Route("linked_list_summ")]
    public class LinkedListSummController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(LinkedList<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LinkedList<int>> Summ(List<LinkedList<int>> lists)
        {
            if (lists == null || lists.Count != 2)
            {
                throw new ArgumentException("Should be two linked lists");
            }

            var firstList = lists[0];
            var secondList = lists[1];

            if (firstList.Count >= secondList.Count)
            {
                return SummLinkedList(firstList, secondList);
            }
            else
            {
                return SummLinkedList(secondList, firstList);
            }
        }

        private LinkedList<int> SummLinkedList(LinkedList<int> firstList, LinkedList<int> secondList)
        {
            var summList = new LinkedList<int>();
            var transfer = false;
            var nodeSecondList = secondList.First;
            var summ = 0;

            for (var nodeFirstList = firstList.First; nodeFirstList != null; nodeFirstList = nodeFirstList.Next)
            {
                if (nodeSecondList == null)
                {
                    summ = nodeFirstList.Value;
                }
                else
                {
                    summ = nodeFirstList.Value + nodeSecondList.Value;
                }


                if (transfer)
                {
                    summ++;
                    transfer = false;
                }
                if (summ >= 10)
                {
                    summ = summ % 10;
                    transfer = true;
                }

                summList.AddLast(summ);
                if (nodeSecondList != null)
                {
                    nodeSecondList = nodeSecondList.Next;
                }
            }

            return summList;
        }
    }
}
