namespace RSSFeed.Common.Utilities.Collections.LinkedList
{
    public class LinkedList
    {
        private Node head;

        // Adds new items to the beginning of an array
        public void Unshift(object data)
        {
            Node newHead = new()
            {
                data = data,
                nextNode = head
            };

            head = newHead;
        }


        // Adds new items to the ending of an array
        public void Push(object data)
        {
            if (head == null)
            {
                head = new Node
                {
                    data = data,
                    nextNode = null
                };
            }
            else
            {
                Node newNode = new()
                {
                    data = data
                };

                Node current = head;

                while (current.nextNode != null)
                {
                    current = current.nextNode;
                }

                current.nextNode = newNode;
            }
        }

        public long Count()
        {
            var acum = 0;
            
            if (head != null)
            {
                acum++;
            }

            Node current = head;

            while (current.nextNode != null)
            {
                current = current.nextNode;
                acum++;
            }

            return acum;
        }
    }
}
