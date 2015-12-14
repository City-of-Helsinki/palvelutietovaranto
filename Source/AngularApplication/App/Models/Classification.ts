"use strict";

module ServiceRegister
{
    export class Classification
    {
        protected selectedClassId: string;

        public expandedAvailable: Array<HierarchicalClass>;
        public addedCollection: HierarchicalClasses;

        constructor(protected availableCollection: HierarchicalClasses, addedIds?: Array<string>)
        {
            this.addedCollection = new HierarchicalClasses();
            this.expandedAvailable = new Array<HierarchicalClass>();
            if (addedIds != null)
            {
                addedIds.forEach((id: string) =>
                {
                    this.toggleSelection(id, true);
                    this.addSelected();
                    this.toggleSelection(id, false);
                });                
            }
        }

        public get added(): Array<HierarchicalClass>
        {
            return this.addedCollection.value;
        }

        public get available(): Array<HierarchicalClass>
        {
            return this.availableCollection.value;
        }

        public isClassSelected(): boolean
        {
            return this.selectedClassId != null;
        }

        public areClassesAdded(): boolean
        {
            return this.added.length > 0;
        }

        public expandAvailable(): void
        {
            if (this.expandedAvailable.length === 0)
            {
                this.pushToExpandedAvailable(this.available);
            }
        }

        public collapseAvailable(): void
        {
            this.expandedAvailable.splice(0, this.expandedAvailable.length);
        }

        public toggleSelection(classId: string, selected: boolean): void
        {
            if (selected)
            {
                this.selectedClassId = classId;
            }
            else
            {
                this.selectedClassId = null;
            }
        }

        public addSelected(): void
        {
            if (this.selectedClassId != null && !this.addedCollection.containsRootClass(this.selectedClassId))
            {
                var availableClass: HierarchicalClass = this.availableCollection.getClass(this.selectedClassId);
                if (availableClass == null)
                {
                    throw new ClassNotAvailableException("Selected class " + this.selectedClassId + " not available.");
                }
                this.added.push(new HierarchicalClass(availableClass.id, availableClass.name, new Array<HierarchicalClass>()));
            }
        }

        public remove(classId: string): void
        {
            this.addedCollection.remove(classId);
        }

        private pushToExpandedAvailable(classes: Array<HierarchicalClass>): void
        {
            if (classes != null)
            {
                classes.forEach((item: HierarchicalClass) =>
                {
                    if (item.children != null && item.children.length > 0)
                    {
                        this.expandedAvailable.push(item);
                        this.pushToExpandedAvailable(item.children);                        
                    }
                });                
            }
        }
    }
}