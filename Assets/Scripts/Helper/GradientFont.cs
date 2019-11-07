using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace UnityEngine.UI
{
    public class GradientFont : BaseMeshEffect
    {
        public override void ModifyMesh(VertexHelper vh)
        {
            if(!enabled)
                return;

            try
            {
                float top = 1e10f;
                float bottom = -1e10f;
                var count = vh.currentVertCount;

                UIVertex vertex = new UIVertex();
                for(int i = 0; i < count; ++i)
                {
                    vh.PopulateUIVertex(ref vertex, i);
                    var vert = vertex.position;
                    if(vert.y > bottom)
                        bottom = vert.y;
                    else if(vert.y < top)
                        top = vert.y;
                }

                for(int i = 0; i < count; i++)
                {
                    vh.PopulateUIVertex(ref vertex, i);
                    vertex.color = Color32.Lerp(color2, color1, (vertex.position.y - top) / (bottom - top));
                    vh.SetUIVertex(vertex, i);
                }
            }
            catch(Exception e)
            {
                //Debug.Log(e);
            }
        }
        /// <summary>
        /// 渐变色1
        /// </summary>
        public Color color1 = Color.white;
        /// <summary>
        /// 渐变色2
        /// </summary>
        public Color color2 = Color.white;
    }
}
