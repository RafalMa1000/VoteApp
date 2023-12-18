import { Component, TemplateRef, OnInit } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import {
  VoterDto,
  CreateVoterCommand,
  VotersClient,
  CandidateDto,
  CandidatesClient,
  CreateCandidateCommand,
  CreateVotingActivityCommand,
  VotingActivitiesClient,
} from '../web-api-client';

@Component({
  selector: 'voting-component',
  templateUrl: './voting.component.html',
  styleUrls: ['./voting.component.scss']
})
export class VotingComponent implements OnInit {
  debug = false;

  voters: VoterDto[];
  selectedVoter: VoterDto;
  newVoterEditor: any = {};
  newVoterModalRef: BsModalRef;

  candidates: CandidateDto[];
  selectedCandidate: CandidateDto;
  newCandidateEditor: any = {};
  newCandidateModalRef: BsModalRef;

  newVotingActivityEditor: any = {};
  newVotingActivityModalRef: BsModalRef;

  constructor(
    private votersClient: VotersClient,
    private candidatesClient: CandidatesClient,
    private votingActivitiesClient: VotingActivitiesClient,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.votersClient.getVoters().subscribe(
      result => {
        this.voters = result.voters;
        if (this.voters.length) {
          this.selectedVoter = this.voters[0];
        }
      },
      error => console.error(error)
    );
    this.candidatesClient.getCandidates().subscribe(
      result => {
        this.candidates = result.candidates;
        if (this.candidates.length) {
          this.selectedCandidate = this.candidates[0];
        }
      },
      error => console.error(error)
    );
  }
  getHasVotedMsg(voter: VoterDto): string {
    let msg = voter.hasVoted ? 'has voted' : '';
    return msg;
  }
  canVote(): boolean {
    let ret: boolean;
    if (this.selectedVoter && this.selectedCandidate && !this.selectedVoter.hasVoted) { ret = true; }
    return ret;
  }


  showNewVoterModal(template: TemplateRef<any>): void {
    this.newVoterModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('name').focus(), 250);
  }
  showNewCandidateModal(template: TemplateRef<any>): void {
    this.newCandidateModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('name').focus(), 250);
  }
  showNewVotingActivityModal(template: TemplateRef<any>): void {
    this.newVotingActivityModalRef = this.modalService.show(template);
  }

  newVoterCancelled(): void {
    this.newVoterModalRef.hide();
    this.newVoterEditor = {};
  }

  newCandidateCancelled(): void {
    this.newCandidateModalRef.hide();
    this.newCandidateEditor = {};
  }

  newVotingActivityCancelled(): void {
    this.newVotingActivityModalRef.hide();
    this.newVotingActivityEditor = {};
  }

  addVoter(): void {
    const voter = {
      id: 0,
      name: this.newVoterEditor.name,
      hasVoted: false,
    } as VoterDto;

    this.votersClient.createVoters(voter as CreateVoterCommand).subscribe(
      result => {
        voter.id = result;
        this.voters.push(voter);
        this.selectedVoter = voter;
        this.newVoterModalRef.hide();
        this.newVoterEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if (errors && errors.Name) {
          this.newVoterEditor.error = errors.Name[0];
        }

        setTimeout(() => document.getElementById('name').focus(), 250);
      }
    );
  }
  addCandidate(): void {
    const candidate = {
      id: 0,
      name: this.newCandidateEditor.name,
      votesCount: 0,
    } as CandidateDto;

    this.candidatesClient.createCandidates(candidate as CreateCandidateCommand).subscribe(
      result => {
        candidate.id = result;
        this.candidates.push(candidate);
        this.selectedCandidate = candidate;
        this.newCandidateModalRef.hide();
        this.newCandidateEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if (errors && errors.Name) {
          this.newCandidateEditor.error = errors.Name[0];
        }

        setTimeout(() => document.getElementById('name').focus(), 250);
      }
    );
  }

  addVotingActivity(): void {
    const votingActivity = {
      voterId: this.selectedVoter.id,
      candidateId: this.selectedCandidate.id,
    } as CreateVotingActivityCommand;

    this.votingActivitiesClient.createVotingActivity(votingActivity as CreateVotingActivityCommand).subscribe(
      result => {
        this.selectedCandidate.votesCount = result;
        this.selectedVoter.hasVoted = true;
        this.newVotingActivityModalRef.hide();
        this.newVotingActivityEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if (errors && errors.VoterId) {
          this.newVotingActivityEditor.voterIdError = errors.VoterId[0];
        }
        if (errors && errors.CandidateId) {
          this.newVotingActivityEditor.candidateIdError = errors.CandidateId[0];
        }

        setTimeout(() => document.getElementById('voter').focus(), 250);
      }
    );
  }
}
