"use strict";

module ServiceRegister
{
    export class HierarchicalClassMapper
    {
        public static map(data: any): Array<HierarchicalClass>
        {
            var result: Array<HierarchicalClass> = new Array<HierarchicalClass>();
            if (data != null)
            {
                data.forEach((item: any) =>
                {
                    result.push(new HierarchicalClass(item.id, item.name, this.map(item.subClasses)));
                });                
            }
            return result;
        }
    }
}  