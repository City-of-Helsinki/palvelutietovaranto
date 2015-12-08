"use strict";

module ServiceRegister
{
    export class HierarchicalSelectionClassification extends Classification
    {
        constructor(available: HierarchicalClasses, addedIds?: Array<string>)
        {
            super(available, addedIds);
        }

        public addSelected(): void
        {
            if (this.selectedClassId != null && !this.addedCollection.containsClass(this.selectedClassId))
            {
                var rootClass: HierarchicalClass = this.availableCollection.getClassCopyWithParentChainAndNoChildren(this.selectedClassId);
                if (rootClass == null)
                {
                    throw new ClassNotAvailableException("Selected class " + this.selectedClassId + " not available.");
                }
                if (this.addedCollection.containsRootClass(rootClass.id))
                {
                    this.addChildToAddedParent(rootClass, rootClass.children[0]);
                }
                else
                {
                    this.added.push(rootClass);
                }
            }
        }

        private addChildToAddedParent(parent: HierarchicalClass, child: HierarchicalClass): void
        {
            if (this.addedCollection.containsClass(child.id))
            {
                this.addChildToAddedParent(parent.children[0], child.children[0]);
            }
            else
            {
                var addedParent: HierarchicalClass = this.addedCollection.getClass(parent.id);
                addedParent.children.push(child);
            }
        }
    }
}