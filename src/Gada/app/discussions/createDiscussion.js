(function () {
    "use strict";

    angular
        .module("app.discussions")
        .controller("CreateDiscussion", CreateDiscussion);

    function CreateDiscussion(discussionsData, genericData, $sessionStorage, $state, commonServices)
    {
        var vm = this;

        if ($sessionStorage.gadaUser === undefined) {
            $state.go('login');
            return false;
        }

        vm.tags = [];

        vm.interests = '';
        loadAllInterests();

        vm.areas = '';
        loadAreas();

        vm.discussion = {
            Title: '',
            Description: '',
            Area: '',
            Interests: []
        };

        vm.orightml = '';
        vm.htmlcontent = vm.orightml;
        vm.disabled = false;

        vm.loadTags = function (query) {
            loadInterests(query);
            return vm.tags;
        };

        function loadAreas() {
            genericData.getAll('areas').then(function(response) {
                vm.areas = response.data;
            });
        };

        function loadAllInterests() {
            genericData.getAll('interests').then(function(response) {
                vm.interests = response.data;
            });
        };

        function loadInterests(query) {
            genericData.find('interests', query).then(function (response) {
                    vm.tags = [];

                    for (var i = 0; i < response.data.length; i++) {
                        var obj = { text: response.data[i].interest };
                        vm.tags.push(obj);
                    }
            });
        };

        vm.createDiscussionSubmit = function () {
            if (vm.discussion.Interests.length === 0) {
                commonServices.showToast('danger', 'Please select at least 1 interest');
            }
            else if (vm.discussion.Area === '') {
                commonServices.showToast('danger', 'Please select an area');
            }
            else if (vm.discussion.Title === '') {
                commonServices.showToast('danger', 'Please enter a title');
            }
            else if (vm.discussion.Description === '') {
                commonServices.showToast('danger', 'Please enter some discussion text');
            }
            else {
                discussionsData.create(vm.discussion).then(function (response) {
                    if (response.status === 200 && response.data !== undefined) {
                        $state.go('discussions');
                    } else {
                        commonServices.showToast('danger', 'There was a problem submitting the form. Please try again');
                    }
                });
            }
        }
    }

})();