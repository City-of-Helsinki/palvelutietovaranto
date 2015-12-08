"use strict";

module ServiceRegister
{
    export class HierarchicalClasses
    {
        public value: Array<HierarchicalClass>;

        constructor(classes?: Array<HierarchicalClass>)
        {
            if (classes == null)
            {
                this.value = new Array<HierarchicalClass>();
            }
            else
            {
                this.value = classes;
            }
        }

        public remove(classId: string): void
        {
            this.removeClass(classId, this.value);
        }

        public containsRootClass(classId: string): boolean
        {
            return this.containsClassOnTopLevel(classId, this.value);
        }

        public containsClass(classId: string): boolean
        {
            return this.containsClassOnAnyLevel(classId, this.value);
        }

        public getClass(classId: string): HierarchicalClass
        {
            return this.getClassFromCollection(classId, this.value);
        }

        public getClassCopyWithParentChainAndNoChildren(classId: string): HierarchicalClass
        {
            return this.getClassCopyWithParentChainAndNoChildrenFromCollection(classId, this.value);
        }

        public getIds(): Array<string>
        {
            return this.getCollectionIds(this.value);
        }

        private containsClassOnTopLevel(classId: string, collection: Array<HierarchicalClass>): boolean
        {
            if (collection != null)
            {
                return collection.some((item: HierarchicalClass) => item.id === classId);
            }
            return false;
        }

        private removeClass(classId: string, collection: Array<HierarchicalClass>): void
        {
            if (collection != null)
            {
                if (this.containsClassOnTopLevel(classId, collection))
                {
                    var foundClass: HierarchicalClass = this.getClassFromCollection(classId, collection);
                    collection.splice(collection.indexOf(foundClass, 0), 1);
                }
                else
                {
                    collection.forEach((item: HierarchicalClass) =>
                    {
                        this.removeClass(classId, item.children);
                    });
                }
            }
        }

        private getClassFromCollection(classId: string, collection: Array<HierarchicalClass>): HierarchicalClass
        {
            if (collection != null)
            {
                if (this.containsClassOnTopLevel(classId, collection))
                {
                    return collection.filter((item: HierarchicalClass) => item.id === classId)[0];
                }
                for (var i = 0; i < collection.length; i++)
                {
                    var foundClass: HierarchicalClass = this.getClassFromCollection(classId, collection[i].children);
                    if (foundClass != null)
                    {
                        return foundClass;
                    }
                }
            }
            return null;
        }

        private containsClassOnAnyLevel(classId: string, collection: Array<HierarchicalClass>): boolean
        {
            if (collection != null)
            {
                if (this.containsClassOnTopLevel(classId, collection))
                {
                    return true;
                }
                for (var i = 0; i < collection.length; i++)
                {
                    if (this.containsClassOnAnyLevel(classId, collection[i].children))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private getClassCopyWithParentChainAndNoChildrenFromCollection(classId: string, collection: Array<HierarchicalClass>): HierarchicalClass
        {
            if (collection != null)
            {
                if (this.containsClassOnTopLevel(classId, collection))
                {
                    var foundClass: HierarchicalClass = this.getClassFromCollection(classId, collection);
                    return new HierarchicalClass(foundClass.id, foundClass.name, new Array<HierarchicalClass>());
                }
                for (var i = 0; i < collection.length; i++)
                {
                    if (this.containsClassOnAnyLevel(classId, collection[i].children))
                    {
                        return new HierarchicalClass(collection[i].id, collection[i].name,
                            new Array<HierarchicalClass>(this.getClassCopyWithParentChainAndNoChildrenFromCollection(classId, collection[i].children)));
                    }
                }
            }
            return null;
        }

        private getCollectionIds(collection: Array<HierarchicalClass>): Array<string>
        {
            var ids: Array<string> = new Array<string>();
            if (collection != null && collection.length > 0)
            {
                for (var i = 0; i < collection.length; i++)
                {
                    ids.push(collection[i].id);
                    ids = ids.concat(this.getCollectionIds(collection[i].children));
                }
            }
            return ids;
        }
    }
}   