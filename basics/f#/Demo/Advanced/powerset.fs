module powerset

let rec powerset l = 
    match l with
        | hd::tl -> 
            let subtail = powerset tl
            [ for subset in subtail do
                yield hd::subset
                ]
        | [] -> [[]]
        
let ll:int list list = powerset [1;2;3]

let rec p l = 
    match l with
        | hd::tl -> let x = p tl
                    [ for y in x do yield hd::y; yield y ]
        | [] -> [[]]
        
        

let p1 l = 
    List.foldBack (fun x acc -> ([ for t in acc do yield x::t ]) @ acc ) l [[]]
    
let rec powerset1 = function
    | [] -> [[]]
    | h::t -> List.fold (fun xs t -> (h::t)::t::xs) [] (powerset1 t);;