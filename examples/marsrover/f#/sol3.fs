module rover3

type DirectionValue = N|S|E|W

type Direction = { direction: DirectionValue;
                 left : DirectionValue;
                 right : DirectionValue;
                 delta : int*int }

let directionMap = Map.ofList [ N,{direction=N;left=W;right=E;delta= 0,1};
                                 E,{direction=E;left=N;right=S;delta= 1,0};  
                                 S,{direction=S;left=E;right=W;delta= 0,-1};  
                                 W,{direction=W;left=S;right=N;delta= -1,0};  
                                 ]

let move (x,y,d) =
    let (dx,dy) = directionMap.[d].delta
    (x+dx,y+dy,d)
   
let turnRight (x,y,d) =
    let nextDir = directionMap.[d].right
    (x,y,nextDir)
   
let turnLeft (x,y,d) =
    let nextDir = directionMap.[d].left
    (x,y,nextDir)
   

let commandMap = Map.ofList ['M',move;'R',turnRight;'L',turnLeft]

// converts a list of string into a list of functions by looking into the commandMap which is a Map of char -> function.
let commands = "LMRRMMLLRLM" |> List.ofSeq |> List.map (fun x -> commandMap.[x])

// f is a single composite function composed of all the series of move and turn functions., >> is the function composition operator,
// it kind of concatenates together a list of functions into a single function..which will be evaluated in series..
// i.e f(g(h(x))) is same as (f >> g >> h) (x)

let f = commands |> List.reduce (>>)

let initPos = (1,1,N)

let finalPos = f(initPos)
