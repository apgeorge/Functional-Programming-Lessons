module rover1
// 0 0 N
// RML
// 1 0 N

type Direction = 
 | N
 | E
 | S
 | W
 
 
let initialPos = ((0,0),N)

type Move = 
 | M
 
type Turn = 
 | R
 | L

type Command = 
 | Move
 | Rotate of Turn
 
let dmap = [(N,R,E);(N,L,W);(S,R,W);(S,L,E);(E,R,S);(E,L,N);(W,R,N);(W,L,S)]
let cmap = [(N,(0,1));(S,(0,-1));(E,(1,0));(W,(-1,0))]
 
let rotate command ((x,y),D) =
 let _,_,D2 = List.find (fun (D1,C,D2) -> D1 = D && command = C )  dmap
 ((x,y),D2)
 
  
let move ((x,y),D) = 
 let _,(dx,dy) = List.find (fun (D1,(dx,dy)) -> D1 = D) cmap
 ((x+dx,y+dy),D)
 

let commands = [Rotate(R);Move;Rotate(L)]

let getCommandFunction(c) = 
 match c with
  | Rotate(r) -> rotate r
  | Move -> move 
  
  
type d = { commad:Command; func: (((int*int)*Direction) -> ((int*int)*Direction)) }

let process (commands:Command list) p = 
 let fn = List.fold (fun f x -> f >> getCommandFunction(x)) id commands
 fn p
 
let (x,y),D = process commands ((0,0),N)



let r = (0,255,124)

 