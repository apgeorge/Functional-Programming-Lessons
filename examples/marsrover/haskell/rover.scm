(define (rover x y) (�� (fn) (fn x y)))
(define (x rover) (rover (�� (a b) a)))
(define (y rover) (rover (�� (a b) b)))
(define (rover-out a-rover) `(,(x a-rover) ,(y a-rover)))

(define (left fn) (fn (�� (left-impl right-impl move-impl out-impl) (left-impl))))

(define (right fn) (fn (�� (left-impl right-impl move-impl out-impl) (right-impl))))

(define (move fn) (fn (�� (left-impl right-impl move-impl out-impl) (move-impl))))

(define (out fn) (fn (�� (left-impl right-impl move-impl out-impl) (out-impl))))



(define (north a-rover)   
  (�� (fn)
    (fn
     (�� () (west a-rover))
     (�� () (east a-rover))
     (�� () (north (rover (x a-rover) (+ (y a-rover) 1))))     
     (�� () `(,(rover-out a-rover) n))
     ))
  )

(define (south a-rover)   
  (�� (fn)
    (fn
     (�� () (east a-rover))
     (�� () (west a-rover))
     (�� () (south (rover (x a-rover) (- (y a-rover) 1))))
     (�� () `(,(rover-out a-rover) s))
     ))
  )

(define (west a-rover)   
  (�� (fn)
    (fn
     (�� () (south a-rover))
     (�� () (north a-rover))
     (�� () (west (rover (- (x a-rover) 1) (y a-rover))))
     (�� () `(,(rover-out a-rover) w))
     ))
  )


(define (east a-rover)   
  (�� (fn)
    (fn
     (�� () (north a-rover))
     (�� () (south a-rover))
     (�� () (east (rover (+ (x a-rover) 1) (y  a-rover))))

     (�� () `(,(rover-out a-rover) e))
     ))
  )

;;tests
;rover x y
(x (rover 2 3))
(y (rover 2 3))
;left
(out (left (north (rover 1 1))))
(out (left (west (rover 1 1))))
(out (left (south (rover 1 1))))
(out (left (east (rover 1 1))))
;right
(out (right (north (rover 1 1))))
(out (right (east (rover 1 1))))
(out (right (south (rover 1 1))))
(out (right (west (rover 1 1))))
;move
(out (move (north (rover 1 1))))
(out (move (south (rover 1 1))))
(out (move (east (rover 1 1))))
(out (move (west (rover 1 1))))
;move-turn
(out (move (move (left (move (left (move (left (move (left (north (rover 1 2))))))))))))
