using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    public class Intersection
    {
        private const int HIT_CACHE_SIZE = 4;
        private HitInfo[] _hitCache = new HitInfo[HIT_CACHE_SIZE];
        private List<HitInfo> _hits = new(HIT_CACHE_SIZE);
        private int _hitCount;

        public Intersection()
        {
            _hitCount = 0;
        }

        public int AddHit(HitInfo hit)
        {
            if (_hitCount < HIT_CACHE_SIZE)
            {
                _hitCache[_hitCount] = hit;
            }
            else
            {
                _hits.Add(hit);
            }

            return _hitCount++;
        }

        public HitInfo GetHit(int index)
        {
            if (index < HIT_CACHE_SIZE)
            {
                return _hitCache[index];
            }
            else
            {
                return _hits[index - HIT_CACHE_SIZE];
            }
        }

        public int GetHitsCount()
        {
            return _hitCount;
        }

        public void Clear()
        {
            if (_hitCount > HIT_CACHE_SIZE)
            {
                _hits.Clear();
            }
            _hitCount = 0;
        }
    }
}
