module order
//algorithm is expressed directly in the code, 
//rather than indirectly as a product of stateful operations and their uncheckable ordering
// In the imperative version the names list1 and list2 both referred to the unsorted and sorted lists depending on where you referenced them, which is the whole root of the problem, 
// whereas in the functional way of thinking only the names sortedList1 and sortedList2 refer to the sorted lists.

let list1 = [2;1;4]
let list2 = [7;3;8]
let comparator = (fun (x:int) (y:int) -> x.CompareTo(y)) 

let sortedList1 = List.sortWith comparator list1
let sortedList2 = List.sortWith comparator list2


let list3 = List.append sortedList1 sortedList2
