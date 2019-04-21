using System;
using System.Collections.Generic;

namespace MergeSort
{
    //Merge Sort Main Algorithm
    public class MergeSort<T> where T : IComparable
    {
        public static List<T> Sort(List<T> toSort)
        {
            //Divide the list
            //When only one element left, indicate that
            //the divide is complete return the list.
            if (toSort.Count == 1)
            {
                return toSort;
            }
            //Calculate the mid point
            //Merge method will handle the 
            //length difference in case of odd number of element
            int mid = toSort.Count / 2;
            //Construct two new list
            //containing left half and right half of original list
            List<T> left = new List<T>();
            for (int i = 0; i < mid; i++)
            {
                left.Add(toSort[i]);
            }
            List<T> right = new List<T>();
            for (int i = mid; i < toSort.Count; i++)
            {
                right.Add(toSort[i]);
            }
            //recursively divide the list
            left = Sort(left);
            right = Sort(right);
            //after divide is complete
            //merge the list and return the result
            return Merge(left, right);

        }

        private static List<T> Merge(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                }else if (left.Count > 0)
                {
                    foreach (var item in left)
                    {
                        result.Add(item);
                    }
                    left = new List<T>();
                }
                else
                {
                    foreach (var item in right)
                    {
                        result.Add(item);
                    }
                    right = new List<T>();
                }
            }

            return result;
        }
    }
}
