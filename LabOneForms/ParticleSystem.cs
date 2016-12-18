using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabOneForms
{
    public class FastList<type> : IList<type>
    {
        public bool allowChangeSize = false;

        private int currentCount = 0;
        private int freeIndex = 0;
        private int loopIndex = 0;

        Tuple<int, type>[] array;

        public int Count
        {
            get
            {
                return currentCount;
            }
        }
        public int FreeIndex { get { return freeIndex; } }
        public bool IsReadOnly
        {
            get
            {
                return !allowChangeSize && currentCount >= array.Length;
            }
        }

        type IList<type>.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                // Unavailable operation
            }
        }

        public FastList()
        {
            array = new Tuple<int, type>[10];//reserve 10
            for (int i = 0; i < 10; ++i)
                array[i] = new Tuple<int, type>((i + 1) % 10, default(type));
        }
        public FastList(int reserveCount)
        {
            if (reserveCount < 0)
                throw new Exception("ReserveCount count can't be less than 0");

            array = new Tuple<int, type>[reserveCount];

            if (reserveCount == 0) return;
            for (int i = 0; i < reserveCount; ++i)
                array[i] = new Tuple<int, type>((i + 1) % reserveCount, default(type));
        }

        /* WARNING: Resizing array to lesser size can cause data loss
        */
        public void Resize(int newSize)
        {
            if (newSize < 0)
                throw new Exception("Bad size");

            Tuple<int, type>[] newArray = new Tuple<int, type>[newSize];

            if (newSize == 0)
            {
                loopIndex = 0;
                freeIndex = 0;
                currentCount = 0;
                return;
            }

            int counterLimit = Math.Min(newSize, currentCount);

            int i = 0;
            foreach (var elem in this)
            {
                newArray[i++] = new Tuple<int, type>((i + 1) % counterLimit, elem);
                if (i >= newSize) break;
            }

            loopIndex = 0;
            freeIndex = i;
            if (newSize < currentCount) currentCount = newSize;
        }

        public void Add(type item)
        {
            if (currentCount >= array.Length)
            {
                if (allowChangeSize)
                    Resize(currentCount == 0 ? 1 : currentCount * 2);
                else
                    return;
            }
            array[freeIndex] = new Tuple<int, type>(array[freeIndex].Item1, item);
            freeIndex = array[freeIndex].Item1;
            if (currentCount == 0) loopIndex = freeIndex;
            ++currentCount;
        }
        public int AddIndex(type item)
        {
            if (IsReadOnly) return -1;
            int insertIndex = FreeIndex;
            Add(item);
            return insertIndex;
        }

        public void Clear()
        {
            Resize(0);
        }

        public bool Contains(type item)
        {
            foreach (var elem in this)
                if (elem.Equals(item)) return true;
            return false;
        }

        public type Get(int index)
        {
            if (index < 0 || index >= array.Length)
                return default(type);//throw new Exception("Bad index");
            return array[index].Item2;
        }

        public void CopyTo(type[] array, int arrayIndex)
        {
            var enumerator = GetEnumerator();
            for (int i = arrayIndex; i < array.Length; ++i)
            {
                array[i] = enumerator.Current;
                if (!enumerator.MoveNext()) break;
            }
        }

        public bool Remove(type item)
        {
            FastListEnumerator<type> enumerator = new FastListEnumerator<type>(array, loopIndex, currentCount);

            do {
                if (enumerator.Current.Equals(item))
                    return Remove(enumerator.Index);
            } while (enumerator.MoveNext());

            return false;
        }

        // Тут я несколько раз голову поломал
        public bool Remove(int index)
        {
            if (currentCount <= 0) return false;
            if (index == freeIndex) return false;

            //Check loop point, reroute if needed
            // Not working currently
            /*if (index == loopIndex)
            {
                loopIndex = array[loopIndex].Item1;
                while(array[loopIndex] == null) loopIndex = array[loopIndex].Item1;
            }*/
            //Reroute and destroy
            array[index] = new Tuple<int, type>(freeIndex, default(type));
            //Make current free
            freeIndex = index;
            //Decrement count
            --currentCount;

            return true;
        }

        public FastListEnumerator<type> GetLiteralEnumerator()
        {
            return new FastListEnumerator<type>(array, loopIndex, currentCount);
        }

        public IEnumerator<type> GetEnumerator()
        {
            return GetLiteralEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetLiteralEnumerator();
        }

        public int IndexOf(type item)
        {
            FastListEnumerator<type> enumerator = new FastListEnumerator<type>(array, loopIndex, currentCount);

            do
            {
                if (enumerator.Current.Equals(item))
                    return enumerator.Index;
            } while (enumerator.MoveNext());

            return -1;
        }

        public void Insert(int index, type item)
        {
            // Unavailable operation
        }

        public void RemoveAt(int index)
        {
            Remove(index);
        }

        public type this[int key]
        {
            get
            {
                return Get(key);
            }
        }
    }

    public class FastListEnumerator<type> : IEnumerator<type>
    {
        Tuple<int, type>[] array;
        int loopIndex;
        int count;

        int currentIndex;
        int currentCount;

        public FastListEnumerator(Tuple<int, type>[] inputArray, int inputLoopIndex, int inputCount)
        {
            array = new Tuple<int, type>[inputArray.Length];
            inputArray.CopyTo(array, 0);//Thread safeness
            loopIndex = inputLoopIndex;
            count = inputCount;
            Reset();
        }

        public int Index
        {
            get
            {
                return currentIndex;
            }
        }

        public type Current
        {
            get
            {
                return array[currentIndex].Item2;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return array[currentIndex].Item2;
            }
        }

        public void Dispose()
        {
            // Not used
        }

        public bool MoveNext()
        {
            //Direct enumerator implementation
            //Warning: slow
            do
            {
                ++currentIndex;
                if (currentIndex >= array.Length) return false;
            } while (array[currentIndex].Item2 == null);
            return true;
            /*if (currentCount >= count) return false;

            currentIndex = array[currentIndex].Item1;
            //if (array[currentIndex].Item2 == null) return false; // Hard protection - loop index messing up
            ++currentCount;

            return true;*/
        }

        public void Reset()
        {
            //currentIndex = loopIndex;
            currentIndex = 0;
            currentCount = 1;
        }
    }

#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public struct Vector
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        public double X, Y;

        public Vector(double a)
        {
            X = a; Y = a;
        }
        public Vector(double X, double Y)
        {
            this.X = X; this.Y = Y;
        }

        public void Normalize()
        {
            this = Normalized(this);
        }
        public Vector Normalized()
        {
            return this = Normalized(this);
        }
        public double Length()
        {
            return Length(this);
        }
        public double SquaredLength()
        {
            return SquaredLength(this);
        }

        public static double Dot(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
        public static Vector Add(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector Subtract(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector Scale(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }
        public static double operator *(Vector a, Vector b)
        {
            return Dot(a, b);
        }
        public static Vector operator *(Vector a, double b)
        {
            return Scale(a, b);
        }
        public static Vector operator /(Vector a, double b)
        {
            return Scale(a, 1.0/b);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return Add(a, b);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return Subtract(a, b);
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return a.X != b.X || a.Y != b.Y;
        }
        public static double SquaredLength(Vector a)
        {
            return a.X * a.X + a.Y * a.Y;
        }
        public static double Length(Vector a)
        {
            return Math.Sqrt(SquaredLength(a));
        }
        public static Vector Normalized(Vector a)
        {
            double len = Length(a);
            return len == 0 ? a : a / len;
        }
        public static Vector FromRotation(double angle)
        {
            return new Vector(Math.Cos(angle), Math.Sin(angle));
        }

        public static readonly Vector Zero = new Vector(0, 0);
        public static readonly Vector Up = new Vector(0, 1);
        public static readonly Vector Right = new Vector(1, 0);

        public string ToString(string numFormat = "")
        {
            return ("(" + X.ToString(numFormat) + ", " + Y.ToString(numFormat) + ")");
        }
    }

    public struct Bounds
    {
        private Vector bottomLeft;
        private Vector size;

        public Vector BottomLeft
        {
            get { return bottomLeft; }
            set
            {
                bottomLeft = value;
                if (bottomLeft.X > size.X) size.X = bottomLeft.X;
                if (bottomLeft.Y > size.Y) size.Y = bottomLeft.Y;
            }
        }
        public Vector Size
        {
            get { return size; }
            set
            {
                size = value;
                if (bottomLeft.X > size.X) bottomLeft.X = size.X;
                if (bottomLeft.Y > size.Y) bottomLeft.Y = size.Y;
            }
        }

        public Vector GetIntersectionNormal(Vector vec)
        {
            Vector normal = new Vector(0, 0);

            if (vec.X < bottomLeft.X)
                normal += new Vector(1, 0);
            else if (vec.X > size.X)
                normal += new Vector(-1, 0);

            if (vec.Y < bottomLeft.Y)
                normal += new Vector(0, 1);
            else if (vec.Y > size.Y)
                normal += new Vector(0, -1);

            return normal.Normalized();
        }
        public Vector GetClamped(Vector vec)
        {
            Vector clamped = vec;

            if (vec.X < bottomLeft.X)
                clamped.X = bottomLeft.X;
            else if (vec.X > size.X)
                clamped.X = size.X;

            if (vec.Y < bottomLeft.Y)
                clamped.Y = bottomLeft.Y;
            else if (vec.Y > size.Y)
                clamped.Y = size.Y;

            return clamped;
        }
    }

    public class Particle : object
    {
        public bool active = true;
        public double time = 0.0;
        public string Time { get { return time.ToString("0.00"); } }
        public Vector position;
        public string Position { get { return position.ToString("0.00"); } }
        public Vector velocity;
        public string Velocity { get { return velocity.ToString("0.00"); } }

        public Particle(Vector pos)
        {
            position = pos;
            velocity = Vector.Zero;
        }
        public Particle(Vector pos, Vector vel)
        {
            position = pos;
            velocity = vel;
        }

        public void AddAcceleration(Vector acceleration)
        {
            velocity += acceleration;
        }
        public void AddAcceleration(Vector acceleration, double duration)
        {
            velocity += acceleration * duration;
        }
        public void Tick(double deltatime)
        {
            position += velocity * deltatime;
            time += deltatime;
        }
        public void SoftPositionFix(Vector newPosition, double tickDeltatime)
        {
            velocity = (newPosition - position) / tickDeltatime;
        }
        public override string ToString()
        {
            return time.ToString("0.0") + ": P" + position.ToString("0.0") + "; V" + velocity.ToString("0.0");
        }
    }

    public enum ParticleSystemBoundActionEnum : byte
    {
        SoftReflect, HardReflect, Acceleration, Kill, Stop, Ingore
    }

    public class ParticleSystem : FastList<Particle>, ITickable, IControllable
    {
        public Vector gravity = new Vector(0, -9.81);
        public double timeDilation = 1.0;
        public double boundsAcceleraion = 90.0;
        public ParticleSystemBoundActionEnum boundsAction = ParticleSystemBoundActionEnum.Acceleration;
        public Bounds bounds;
        public double particleLifetime = 15.0;

        private double dampingFactor = 0.98;
        public double DampingFactor
        {
            get { return dampingFactor; }
            set { dampingFactor = Helpers.Clamp(value, 0, 1); }
        }
        Random rand = new Random();

        public ParticleSystem() : base() { }
        public ParticleSystem(int reserveCount) : base(reserveCount) { }

        public void RecieveOwningController(Controller controller)
        {
            controller.GetTickMachine().AddTickable(this);
        }

        public void Tick(double deltatime)
        {
            double dilatedDeltaTime = deltatime * timeDilation;

            var enumerator = GetLiteralEnumerator();
            do // same as foreach but with index
            {
                Particle particle = this[enumerator.Index];
                if (particle == null) continue;
                if (!particle.active) continue;

                particle.AddAcceleration(gravity, dilatedDeltaTime);

                BoundCheck(enumerator.Index, dilatedDeltaTime);

                particle.Tick(dilatedDeltaTime);

                particle.velocity *= Math.Pow(dampingFactor, 60 * dilatedDeltaTime); // Target FPS is 60

                if (particle.time >= particleLifetime)
                    Remove(enumerator.Index);
            } while (enumerator.MoveNext());
        }

        public Point[] AsPointsArray(double deltatime)
        {
            Point[] points = new Point[2 * Count];

            int i = 0;
            foreach (var particle in this)
            {
                points[i++] = new Point((int)(particle.position.X), (int)(particle.position.Y));
                points[i++] = new Point((int)(particle.position.X + particle.velocity.X * deltatime), (int)(particle.position.Y + particle.velocity.Y * deltatime));
            }

            return points;
        }
        public Vector[] AsVectorArray(double deltatime)
        {
            Vector[] points = new Vector[2 * Count];

            int i = 0;
            foreach (var particle in this)
            {
                points[i++] = new Vector(particle.position.X, particle.position.Y);
                points[i++] = new Vector(particle.position.X + particle.velocity.X * deltatime, particle.position.Y + particle.velocity.Y * deltatime);
            }

            return points;
        }

        public int SpawnRandomParticle(Vector position, double maxVelocity)
        {
            Particle p = new Particle(position);
            p.velocity = Vector.FromRotation(rand.NextDouble() * Math.PI * 2) * rand.NextDouble() * maxVelocity;
            return AddIndex(p);
        }
        public void SpawnRandomParticles(int num, Vector position, double maxVelocity)
        {
            for (int i = 0; i < num; ++i)
            {
                Particle p = new Particle(position);
                p.velocity = Vector.FromRotation(rand.NextDouble() * Math.PI * 2) * rand.NextDouble() * maxVelocity;
                Add(p);
            }
        }

        void BoundCheck(int index, double deltatime)
        {
            Particle particle = this[index];
            Vector reflect;
            switch (boundsAction)
            {
                case ParticleSystemBoundActionEnum.Acceleration:
                    reflect = bounds.GetIntersectionNormal(particle.position);
                    particle.AddAcceleration(reflect * boundsAcceleraion);
                    break;
                case ParticleSystemBoundActionEnum.HardReflect:
                    reflect = bounds.GetIntersectionNormal(particle.position);
                    if (reflect != Vector.Zero)
                        particle.position = bounds.GetClamped(particle.position);
                    break;
                case ParticleSystemBoundActionEnum.Ingore:
                    // Literally ignore
                    break;
                case ParticleSystemBoundActionEnum.Kill:
                    Remove(index);
                    break /*particle's life*/;
                case ParticleSystemBoundActionEnum.SoftReflect:
                    reflect = bounds.GetIntersectionNormal(particle.position);
                    if (reflect != Vector.Zero)
                        particle.SoftPositionFix(bounds.GetClamped(particle.position), deltatime);
                    break;
                case ParticleSystemBoundActionEnum.Stop:
                    particle.active = false;
                    break;
            }
        }
    }
}
